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
  public  class QuoteTrackingBL
    {
        Global _global = new Global();
        public Response<QuoteTrackingRegisterDto> Save(QuoteTrackingRegisterDto data)
        {
            Response<QuoteTrackingRegisterDto> obj = null;
            
                var hCliente = _global.rspClient("QuoteTracking/", data);
                if (hCliente.IsSuccessStatusCode)
                {
                    obj = new JavaScriptSerializer().Deserialize<Response<QuoteTrackingRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
                }
                return obj;            
        }

        public Response<ListQuoteTrackingDto> Update(QuoteTrackingUpdateDto data)
        {
            Response<ListQuoteTrackingDto> obj = null;

            var hCliente = _global.rspClientPUT("QuoteTracking/"+ data.QuoteTrackingId, data);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ListQuoteTrackingDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<ListQuoteTrackingDto> GetQuoteTracking(int id)
        {
            Response<ListQuoteTrackingDto> obj = null;

            var hCliente = _global.rspClientGET("QuoteTracking/"+id);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<ListQuoteTrackingDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;

        }

    }
}
