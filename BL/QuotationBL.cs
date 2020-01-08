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
    }
}
