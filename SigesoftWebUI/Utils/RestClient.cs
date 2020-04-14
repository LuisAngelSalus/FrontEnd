using BE;
using BL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SigesoftWebUI.Utils
{
    public class RestClient
    {
        private const string _mediaType = "application/json";
        private readonly string _serviceUrl = ConfigurationManager.AppSettings["SigesoftWebApiUrl"];

        public T GetAsync<T>(string path, SessionModel sessionModel) where T : class, new()
        {
            try
            {
                var responseBody = string.Empty;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", sessionModel.Token);

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

        public T PostAsync<T>(string path, object obj, SessionModel sessionModel)
        {

            try
            {
                var responseBody = string.Empty;
                T item;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", sessionModel.Token);

                    var postBody = new StringContent(JsonConvert.SerializeObject(obj).ToString(),
                        Encoding.UTF8, "application/json");

                    var response = client.PostAsync(path, postBody).Result;

                    response.EnsureSuccessStatusCode();

                    responseBody = response.Content.ReadAsStringAsync().Result;
                }

                item = JsonConvert.DeserializeObject<T>(responseBody);
                return item;
            }
            catch (Exception ex)
            {
                ErrorUtilities.AddLog(ex);
                throw new InvalidOperationException("RestClient.PostAsync error " + ex.Message);
            }
        }

        public T PutAsync<T>(string path, object obj, SessionModel sessionModel)
        {

            try
            {
                var responseBody = string.Empty;
                T item;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", sessionModel.Token);

                    var putBody = new StringContent(JsonConvert.SerializeObject(obj).ToString(),
                        Encoding.UTF8, "application/json");

                    var response = client.PutAsync(path, putBody).Result;

                    response.EnsureSuccessStatusCode();

                    responseBody = response.Content.ReadAsStringAsync().Result;
                }

                item = JsonConvert.DeserializeObject<T>(responseBody);
                return item;
            }
            catch (Exception ex)
            {
                ErrorUtilities.AddLog(ex);
                throw new InvalidOperationException("RestClient.PutAsync error " + ex.Message);
            }
        }

        public T DeleteAsync<T>(string path, SessionModel sessionModel) where T : class, new()
        {
            try
            {
                var responseBody = string.Empty;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", sessionModel.Token);

                    var response = client.DeleteAsync(path).Result;

                    response.EnsureSuccessStatusCode();

                    responseBody = response.Content.ReadAsStringAsync().Result;
                }

                var list = JsonConvert.DeserializeObject<T>(responseBody);

                return list;
            }
            catch (Exception ex)
            {
                ErrorUtilities.AddLog(ex);
                throw new InvalidOperationException("RestClient.DeleteAsync error " + ex.Message);
            }
        }


        public async Task<IEnumerable<T>> PostListAsync<T>(string path, object obj, SessionModel sessionModel) where T : class, new()
        {
            try
            {
                var responseBody = string.Empty;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", sessionModel.Token);

                    var postBody = new StringContent(JsonConvert.SerializeObject(obj).ToString(),
                        Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(path, postBody);

                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();
                }

                var list = JsonConvert.DeserializeObject<IEnumerable<T>>(responseBody);

                return list;
            }
            catch (Exception ex)
            {
                ErrorUtilities.AddLog(ex);
                throw new InvalidOperationException("RestClient.PostListAsync error " + ex.Message);
            }
        }
    }
}