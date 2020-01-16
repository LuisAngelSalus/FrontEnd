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

        public Response<QuotationDto> GetQuotation(int quotationId)
        {
            Response<QuotationDto> obj = null;
            var hCliente = _global.rspClientGET("Quotation/" + quotationId);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<ProtocolProfileDto> GetProfile(int profileId)
        {
            Response<ProtocolProfileDto> obj = null;
            var hCliente = _global.rspClientGET("ProtocolProfile/" + profileId);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ProtocolProfileDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
        
        public Response<QuotationRegisterDto> Save(QuotationRegisterDto data)
        {
            Response<QuotationRegisterDto> obj = null;
                var hCliente = _global.rspClient("Quotation/", data);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<QuotationRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
                return obj;         
        }

        public Response<QuotationUpdateDto> Update(QuotationUpdateDto data)
        {
            Response<QuotationUpdateDto> obj = null;
            var hCliente = _global.rspClientPUT("Quotation/", data);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationUpdateDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<QuotationRegisterDto> NewVersion(QuotationNewVersionDto data)
        {
            Response<QuotationRegisterDto> obj = null;
            var hCliente = _global.rspClient("Quotation/NewVersion/", data);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<QuotationFilterDto>> Filter(ParamsQuotationFilterDto parameters)
        {
            Response<List<QuotationFilterDto>> obj = null;
            var hCliente = _global.rspClient("Quotation/Filter/", parameters);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<QuotationFilterDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<ListComponentDto>> GetComponents()
        {
            Response<List<ListComponentDto>> obj = null;
            var hCliente = _global.rspClientGET("ComponentWin/");
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListComponentDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }
        
    }
}
