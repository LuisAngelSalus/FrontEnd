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
   public class ProtocolBL
    {
        Global _global = new Global();
        public Response<List<ProtocolListDto>> GetProtocolsByCompanyId(int id, string token)
        {
            Response<List<ProtocolListDto>> obj = null;
            var hCliente = _global.rspClientGET("Protocol/"+id+"/ProcolosPorEmpresa", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ProtocolListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
