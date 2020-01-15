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
        public Response<ProtocolProfileRegisterDto> Save(ProtocolProfileRegisterDto data)
        {
            Response<ProtocolProfileRegisterDto> obj = null;
            if (!string.IsNullOrEmpty(data.Name))
            {
                var hCliente = _global.rspClient("ProtocolProfile/", data);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<ProtocolProfileRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
               
            }
            return obj;
            //else
            //{
            //    var hCliente = _global.rspClient("Company/", data);
            //    if (hCliente.IsSuccessStatusCode)
            //    {
            //        obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
            //    }
            //    return obj;
            //}
        }

        public Response<List<DropdownListDto>> DropdownList()
        {
            Response<List<DropdownListDto>> obj = null;
            var hCliente = _global.rspClientGET("ProtocolProfile/DropdownList");
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<DropdownListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<DropdownListDto>> Autocomplete(string value)
        {
            Response<List<DropdownListDto>> obj = null;
            var hCliente = _global.rspClientGET("ProtocolProfile/"+value+"/AutocompleteByName");
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<DropdownListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
