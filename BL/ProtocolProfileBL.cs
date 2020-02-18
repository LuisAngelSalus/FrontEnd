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
   public class ProtocolProfileBL
    {
        Global _global = new Global();
        public Response<ProtocolProfileRegisterDto> Save(ProtocolProfileRegisterDto data, string token)
        {
            Response<ProtocolProfileRegisterDto> obj = null;
            if (!string.IsNullOrEmpty(data.Name))
            {
                var hCliente = _global.rspClient("ProtocolProfile/", data, token);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<ProtocolProfileRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
               
            }
            return obj;            
        }

        public Response<List<DropdownListDto>> DropdownList(string token)
        {
            Response<List<DropdownListDto>> obj = null;
            var hCliente = _global.rspClientGET("ProtocolProfile/DropdownList", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<DropdownListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<DropdownListDto>> Autocomplete(string value, string token)
        {
            Response<List<DropdownListDto>> obj = null;
            var hCliente = _global.rspClientGET("ProtocolProfile/"+value+"/AutocompleteByName", token);
            
            if (hCliente.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new JavaScriptSerializer().Deserialize<Response<List<DropdownListDto>>>(hCliente.Content.ReadAsStringAsync().Result);

            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<DropdownListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
