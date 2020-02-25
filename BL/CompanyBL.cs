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

        public Response<List<ListCompanyDto>> Companies(ParamsCompanyFilterModel data ,string token)
        {
            Response<List<ListCompanyDto>> obj = null;
            var hCliente = _global.rspClient("Company/Filter", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListCompanyDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<CompanyDetailDto> CompanyDetail(int companyId, string token)
        {
            Response<CompanyDetailDto> obj = null;
            var hCliente = _global.rspClientGET("Company/"+ companyId + "/sedes", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<CompanyDetailDto> Save(CompanyDetailDto data, string token)
        {
            Response<CompanyDetailDto> obj = null;
            if (data.CompanyId != 0)
            {
                var hCliente = _global.rspClientPUT("Company/"+ data.CompanyId, data, token);

                if (hCliente.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }

                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
                return obj;
            }
            else
            {
                var hCliente = _global.rspClient("Company/", data, token);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
                return obj;
            }                     
        }

        public Response<List<ListCompanyContactDto>> Contacts(int companyId,string token)
        {
            Response<List<ListCompanyContactDto>> obj = null;
            var hCliente = _global.rspClientGET("CompanyContact/" + companyId + "/contactos", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListCompanyContactDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<CompanyDetailDto> CompanyByRuc(string ruc, string token)
        {
            Response<CompanyDetailDto> obj = null;
            var hCliente = _global.rspClientGET("Company/" + ruc, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<CompanyDetailDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            else
            {
                obj = new Response<CompanyDetailDto>();
            }
            return obj;
        }

        public Response<List<ListCompanyDto>> AutocompleteByName(string value,string token)
        {
            Response<List<ListCompanyDto>> obj = null;
            var hCliente = _global.rspClientGET("Company/"+ value + "/AutocompleteByName", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListCompanyDto>>>(hCliente.Content.ReadAsStringAsync().Result);        

            }
            return obj;
        }

        
    }
}
