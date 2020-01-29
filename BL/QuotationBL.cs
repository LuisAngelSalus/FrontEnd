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
    public class QuotationBL
    {
        Global _global = new Global();

        public Response<QuotationDto> GetQuotation(int quotationId, string token)
        {
            Response<QuotationDto> obj = null;
            var hCliente = _global.rspClientGET("Quotation/" + quotationId, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<ProtocolProfileDto> GetProfile(int profileId,string token)
        {
            Response<ProtocolProfileDto> obj = null;
            var hCliente = _global.rspClientGET("ProtocolProfile/" + profileId, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ProtocolProfileDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
        
        public Response<QuotationRegisterDto> Save(QuotationRegisterDto data, string token)
        {
            Response<QuotationRegisterDto> obj = null;
                var hCliente = _global.rspClient("Quotation/", data, token);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<QuotationRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
                return obj;         
        }

        public Response<QuotationUpdateDto> Update(QuotationUpdateDto data, string token)
        {
            Response<QuotationUpdateDto> obj = new Response<QuotationUpdateDto>() ;
            var hCliente = _global.rspClientPUT("Quotation/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationUpdateDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<QuotationRegisterDto> NewVersion(QuotationNewVersionDto data, string token)
        {
            Response<QuotationRegisterDto> obj = null;
            var hCliente = _global.rspClient("Quotation/NewVersion/", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<QuotationFilterDto>> Filter(ParamsQuotationFilterDto parameters, string token)
        {
            Response<List<QuotationFilterDto>> obj = null;
            var hCliente = _global.rspClient("Quotation/Filter/", parameters, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<QuotationFilterDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<ListComponentDto>> GetComponents(string token)
        {
            Response<List<ListComponentDto>> obj = null;
            var hCliente = _global.rspClientGET("ComponentWin/", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListComponentDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<QuotationVersionDto>> GetVersions(string code, string token)
        {
            Response<List<QuotationVersionDto>> obj = null;
            var hCliente = _global.rspClientGET("Quotation/Versions/" + code, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<QuotationVersionDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<bool> UpdateProccess(QuotationUpdateProcess data, string token)
        {
            Response<bool> obj = null;
            var hCliente = _global.rspClientPUT("Quotation/Process", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        
    }
}
