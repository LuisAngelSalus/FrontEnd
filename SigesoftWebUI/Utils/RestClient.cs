using BE;
using BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SigesoftWebUI.Utils
{
    public class RestClient
    {
        SecurityBL _securityBL = new SecurityBL();

        private const string _mediaType = "application/json";
        readonly string _serviceUrl = ConfigurationManager.AppSettings["SigesoftWebApiUrl"];

        private string GetToken(SessionModel sessionModel)
        {
            string token = string.Empty;

            var oLoginDto = new LoginDto()
            {
                v_UserName = sessionModel.UserName,
                v_Password = sessionModel.Pass
            };

            var validated = _securityBL.ValidateAccess(oLoginDto);
            token = validated == null ? "" : validated.Token;

            return token;
        }

        public T GetAsync<T>(string path, SessionModel sessionModel) where T : class, new()
        {
            try
            {
                var responseBody = string.Empty;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken(sessionModel));

                    var response = client.GetAsync(path).Result;

                    response.EnsureSuccessStatusCode();

                    responseBody = response.Content.ReadAsStringAsync().Result;
                }

                var list = JsonConvert.DeserializeObject<T>(responseBody);

                return list;
            }
            catch (Exception ex)
            {
                ErrorUtilities.AddLog(ex);
                throw new InvalidOperationException("RestClient.GetAsync error " + ex.Message);
            }
        }

    }
}