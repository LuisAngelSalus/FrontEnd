using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utils;

namespace BL
{
   public class SuscriptionBL
    {
        Global _global = new Global();

        public Response<string> GetKeyPublic(string token)
        {
            Response<string> obj = null;
            var hCliente = _global.rspClientGET("Suscription/ObtenerClavePublica", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<string>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            else
            {
                obj = new Response<string>();
            }
            return obj;
        }

        public Response<bool> Save(SuscriptionRegisterDto data, string token)
        {
            Response<bool> obj = null;

            var hCliente = _global.rspClient("Suscription/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<bool> Push(SuscriptionPushDto data, string token)
        {
            Response<bool> obj = null;

            var hCliente = _global.rspClient("Suscription/sendNotification/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

    }
}
