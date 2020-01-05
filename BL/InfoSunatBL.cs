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
   public class InfoSunatBL
    {
        Global _global = new Global();
        public Response<InfoDto> info(string ruc)
        {
            Response<InfoDto> obj = null;
            var hCliente = _global.rspClientGET("Info/" + ruc);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<InfoDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
