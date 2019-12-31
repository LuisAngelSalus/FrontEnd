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
    public class CompanyBL
    {
        Global _global = new Global();

        public Response<List<ListCompanyDto>> Companies()
        {
            Response<List<ListCompanyDto>> obj = null;
            var hCliente = _global.rspClientGET("Company");
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListCompanyDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<CompanyDetailDto> CompanyDetail(int companyId)
        {
            Response<CompanyDetailDto> obj = null;
            var hCliente = _global.rspClientGET("Company/"+ companyId + "/sedes");
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<CompanyDetailDto> Save(CompanyDetailDto data)
        {
            Response<CompanyDetailDto> obj = null;
            if (data.CompanyId != 0)
            {
                var hCliente = _global.rspClientPUT("Company/"+ data.CompanyId, data);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
                return obj;
            }
            else
            {
                var hCliente = _global.rspClient("Company/", data);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
                return obj;
            }                     
        }

        public Response<List<ListCompanyContactDto>> Contacts(int companyId)
        {
            Response<List<ListCompanyContactDto>> obj = null;
            var hCliente = _global.rspClientGET("CompanyContact/" + companyId + "/contactos");
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListCompanyContactDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
    }
}
