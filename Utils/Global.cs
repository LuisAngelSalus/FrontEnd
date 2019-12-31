using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utils
{
    public class Global
    {
        readonly string _apiUrl = ConfigurationManager.AppSettings["SigesoftWebApiUrl"];
        public string rspwClient(string webService, object input)
        {
            string serviceUrl = _apiUrl + webService;

            string inputJson = (new JavaScriptSerializer()).Serialize(input);

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string heatmap = client.UploadString(serviceUrl, inputJson);
            return heatmap;
        }

        public HttpResponseMessage rspClient(string webService, object input)
        {
            var inputJson = JsonConvert.SerializeObject(input);

            HttpClient client = new HttpClient();

            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(_apiUrl + webService, inputContent).Result;

            return response;
        }

        public HttpResponseMessage rspClientPUT(string webService, object input)
        {
            var inputJson = JsonConvert.SerializeObject(input);

            HttpClient client = new HttpClient();

            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(_apiUrl + webService, inputContent).Result;

            return response;
        }

        public HttpResponseMessage rspClientGET(string webService)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(_apiUrl + webService).Result;

            return response;
        }
    }
}
