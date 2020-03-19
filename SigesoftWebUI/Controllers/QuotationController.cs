using BE;
using BL;
using SigesoftWebUI.Controllers.Base;

//using iTextSharp.text;
//using iTextSharp.text.pdf;
using SigesoftWebUI.Repositories;
using System;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class QuotationController : GenericController
    {
        private readonly QuotationRepository quotationRepository = new QuotationRepository();

        private QuotationBL _quotationBL = new QuotationBL();
        private CompanyBL _companyBL = new CompanyBL();
        private SecurityBL _securityBL = new SecurityBL();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Filter(ParamsQuotationFilterDto parameters)
        {
            parameters.ResponsibleSystemUserId = SessionUsuario.SystemUserId;
            var response = _quotationBL.Filter(parameters, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuotation(int id)
        {
            var response = _quotationBL.GetQuotation(id, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register(int id, string ruc)
        {
            if (id == 0)
            {
                var data = new QuotationDto();
                var company = _companyBL.CompanyByRuc(ruc, SessionUsuario.Token).Data;
                data.CompanyId = company.CompanyId;
                data.CompanyRuc = company.IdentificationNumber;
                data.CompanyName = company.Name;
                data.CompanyDistrictName = company.District;
                data.CompanyAddress = company.Address;
                data.FullName = company.ContactName;
                data.Email = company.Mail;
                ViewBag.Headquarters = company.companyHeadquarter;
                ViewBag.DataQuotation = data;
            }
            else
            {
                var response = _quotationBL.GetQuotation(id, SessionUsuario.Token);
                if (response != null)
                {
                    ViewBag.DataQuotation = response.Data;
                    ViewBag.Headquarters = _companyBL.CompanyDetail(response.Data.CompanyId, SessionUsuario.Token).Data.companyHeadquarter;
                }
                else
                {
                    var oQuotationDto = new QuotationDto();
                    ViewBag.DataQuotation = oQuotationDto;
                }
            }

            return View();
        }

        public JsonResult GetProfile(int profileId)
        {
            var response = _quotationBL.GetProfile(profileId, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(QuotationRegisterDto data)
        {
            #region AUDIT

            data.InsertUserId = SessionUsuario.SystemUserId;
            data.ResponsibleSystemUserId = SessionUsuario.SystemUserId;

            #endregion AUDIT

            var response = _quotationBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NewVersion(QuotationNewVersionDto data)
        {
            #region AUDIT

            data.InsertUserId = SessionUsuario.SystemUserId;
            data.ResponsibleSystemUserId = SessionUsuario.SystemUserId;

            #endregion AUDIT

            var response = _quotationBL.NewVersion(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(QuotationUpdateDto data)
        {
            var response = _quotationBL.Update(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetComponents()
        {
            var response = _quotationBL.GetComponents(SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        //public FileResult GetHTMLPageAsPDF()
        //{
        //    var Renderer = new IronPdf.HtmlToPdf();
        //    var PDF = Renderer.RenderHtmlAsPdf(Generator.GetHTMLString());
        //    var contentLength = PDF.BinaryData.Length;
        //    Response.AppendHeader("Content-Length", contentLength.ToString());
        //    Response.AppendHeader("Content-Disposition", "inline; filename=Document_" + "demo" + ".pdf");
        //    return File(PDF.BinaryData, "application/pdf;");
        //}

        public JsonResult GetVersions(string code)
        {
            var response = _quotationBL.GetVersions(code, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExportToPDF(string data)
        {
            //RootObject deserializeQuotation = JsonConvert.DeserializeObject<RootObject>(data);
            //return View(deserializeQuotation);
            //RootObject deserializeQuotation = JsonConvert.DeserializeObject<RootObject>(data);
            //string viewContent = ConvertViewToString("ExportToPDF", deserializeQuotation);
            //return Json(new { PartialView = viewContent });
            return Json(data, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateProccess(QuotationUpdateProcess data)
        {
            var response = _quotationBL.UpdateProccess(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }

        public FileResult ExportPlantilla(int code)
        {
            var quotation = quotationRepository.GetQuotation(code, SessionUsuario);
            MemoryStream memoryStream = quotationRepository.GetPDF(quotation);

            string fileName = string.Empty;
            DateTime fileCreationDatetime = DateTime.Now;
            fileName = string.Format("{0}_{1}.pdf", quotation.Data.Code, fileCreationDatetime.ToString(@"yyyyMMdd") + "_" + fileCreationDatetime.ToString(@"HHmmss"));

            return File(memoryStream, "application/pdf", fileName);
        }

        public JsonResult ListPrice(int CompanyId)
        {
            var response = _quotationBL.GetListPrice(CompanyId, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetPrice(PriceListDto data)
        {
            data.InsertUserId = SessionUsuario.SystemUserId;
            data.UpdateUserId = SessionUsuario.SystemUserId;
            var response = _quotationBL.UpdatePriceList(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MigrateQuotationToProtocols(QuotationMigrateDto data)
        {
            var response = _quotationBL.MigrateQuotationToProtocols(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Trackingchart(ParamsTrackingChartModel parameters)
        {
            parameters.ResponsibleSystemUserId = SessionUsuario.SystemUserId;
            var response = _quotationBL.Trackingchart(parameters, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MigrateProtocolToSIGESoftWin(QuotationMigrateDto data)
        {
            var response = _quotationBL.MigrateProtocolToSIGESoftWin(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}