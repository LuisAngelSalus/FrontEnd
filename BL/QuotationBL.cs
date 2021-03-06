﻿using BE;
using NetPdf;
using System;
using System.Collections.Generic;
using System.IO;
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
        {//REFACTOR
            Response<QuotationRegisterDto> obj = null;

            if(data.StatusQuotationId == StateQuotation.Potencial) data.CommercialTerms = "Cotización Potencial";

            var hCliente = _global.rspClient("Quotation/", data, token);
            if (hCliente.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);                
            }                                

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
        {//REFACTOR
            Response<QuotationRegisterDto> obj = null;
            
            var hCliente = _global.rspClient("Quotation/NewVersion/", data, token);
            if (hCliente.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<QuotationRegisterDto>>(hCliente.Content.ReadAsStringAsync().Result);
            }

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

            if (hCliente.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new JavaScriptSerializer().Deserialize<Response<List<QuotationFilterDto>>>(hCliente.Content.ReadAsStringAsync().Result); 

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

        public Response<List<PriceListDto>> GetListPrice(int companyId, string token)
        {
            Response<List<PriceListDto>> obj = null;
            var hCliente = _global.rspClientGET("PriceList/" + companyId+ "/ListaPrecio", token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<PriceListDto>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<bool> UpdatePriceList(PriceListDto data, string token)
        {
            Response<bool> obj = null;
            var hCliente = _global.rspClientPUT("PriceList/" + data.CompanyId, data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<bool> MigrateQuotationToProtocols(QuotationMigrateDto data, string token)
        {
            Response<bool> obj = null;
            var hCliente = _global.rspClient("Quotation/MigrateToProtocols", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<List<ListTrackingChartModel>> Trackingchart(ParamsTrackingChartModel parameters, string token) {
            Response<List<ListTrackingChartModel>> obj = null;
            var hCliente = _global.rspClient("Quotation/GraficoSeguimiento/", parameters, token);

            if (hCliente.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new JavaScriptSerializer().Deserialize<Response<List<ListTrackingChartModel>>>(hCliente.Content.ReadAsStringAsync().Result);

            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<List<ListTrackingChartModel>>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public Response<bool> MigrateProtocolToSIGESoftWin(QuotationMigrateDto data, string token)
        {
            Response<bool> obj = null;
            var hCliente = _global.rspClient("Quotation/MigrateProtocolToSigesoftWin", data, token);
            if (hCliente.IsSuccessStatusCode)
            {
                obj = new JavaScriptSerializer().Deserialize<Response<bool>>(hCliente.Content.ReadAsStringAsync().Result);
            }
            return obj;
        }

        public MemoryStream GeneratePdf(int code)
        {            
           return QuotationDocumentPDF.CreateDocument(code);
        }

    }
}
