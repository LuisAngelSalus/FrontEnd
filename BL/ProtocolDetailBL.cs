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
   public class ProtocolDetailBL
    {
        Global _global = new Global();
        public Response<List<ProtocolDetailListDto>> GetProtocolDetailByProtocolId(int id, string token)
        {
            Response<List<ProtocolDetailListDto>> obj = null;
            var hCliente = _global.rspClientGET("ProtocolDetail/" + id + "/DetalleProtocolo", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ProtocolDetailListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<ProtocolDetailListDto> Save(ProtocolDetailRegisterDto data, string token)
        {
            Response<ProtocolDetailListDto> obj = null;

            var hCliente = _global.rspClient("ProtocolDetail/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ProtocolDetailListDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;

        }
    }
}
