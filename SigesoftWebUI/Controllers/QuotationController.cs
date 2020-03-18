using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utils;
using IronPdf;
using SigesoftWebUI.Utils.PDF;
using SigesoftWebUI.Controllers.Base;
using Newtonsoft.Json;
using SigesoftWebUI.Models;
using System.Data;
using Newtonsoft.Json.Linq;

using System.IO;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using Spire.Doc;
using SigesoftWebUI.Utils;
using SigesoftWebUI.Repositories;

namespace SigesoftWebUI.Controllers
{
    public class QuotationController : GenericController
    {
        private readonly QuotationRepository quotationRepository = new QuotationRepository();


        QuotationBL _quotationBL = new QuotationBL();
        CompanyBL _companyBL = new CompanyBL();
        SecurityBL _securityBL = new SecurityBL();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Filter(ParamsQuotationFilterDto parameters)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion
            parameters.ResponsibleSystemUserId = validated.SystemUserId;
            var response = _quotationBL.Filter(parameters, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetQuotation(int id)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.GetQuotation(id, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register(int id, string ruc)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            if (id == 0)
            {
                var data = new QuotationDto();
                var company = _companyBL.CompanyByRuc(ruc, validated.Token).Data;
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
                var response = _quotationBL.GetQuotation(id, validated.Token);
                if (response != null)
                {
                    ViewBag.DataQuotation = response.Data;
                    ViewBag.Headquarters = _companyBL.CompanyDetail(response.Data.CompanyId, validated.Token).Data.companyHeadquarter;
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
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.GetProfile(profileId, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Save(QuotationRegisterDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            #region AUDIT
            data.InsertUserId = sessione.SystemUserId;
            data.ResponsibleSystemUserId = sessione.SystemUserId;
            #endregion

            var response = _quotationBL.Save(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult NewVersion(QuotationNewVersionDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            #region AUDIT
            data.InsertUserId = sessione.SystemUserId;
            data.ResponsibleSystemUserId = sessione.SystemUserId;
            #endregion

            var response = _quotationBL.NewVersion(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(QuotationUpdateDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.Update(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetComponents()
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.GetComponents(validated.Token);
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
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.GetVersions(code, validated.Token);
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
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.UpdateProccess(data, validated.Token);
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
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            var quotation = quotationRepository.GetQuotation(code, SessionUsuario);
            MemoryStream memoryStream = quotationRepository.GetPDF(quotation, sessione.FullName);

            string fileName = string.Empty;
            DateTime fileCreationDatetime = DateTime.Now;
            fileName = string.Format("{0}_{1}.pdf", quotation.Data.Code, fileCreationDatetime.ToString(@"yyyyMMdd") + "_" + fileCreationDatetime.ToString(@"HHmmss"));

            return File(memoryStream, "application/pdf", fileName);
        }

        //public FileResult ExportPlantilla(int code)
        //{
        //    var memoryStream = _quotationBL.GeneratePdf(code);            
        //    DateTime fileCreationDatetime = DateTime.Now;
        //    var fileName = string.Format("{0}_{1}.pdf", code, fileCreationDatetime.ToString(@"yyyyMMdd") + "_" + fileCreationDatetime.ToString(@"HHmmss"));

        //    return File(memoryStream, "application/pdf", fileName);
        //}

        public JsonResult ListPrice(int CompanyId)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.GetListPrice(CompanyId, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetPrice(PriceListDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion
            data.InsertUserId = sessione.SystemUserId;
            data.UpdateUserId = sessione.SystemUserId;
            var response = _quotationBL.UpdatePriceList(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MigrateQuotationToProtocols(QuotationMigrateDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.MigrateQuotationToProtocols(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Trackingchart(ParamsTrackingChartModel parameters)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion
            parameters.ResponsibleSystemUserId = validated.SystemUserId;
            var response = _quotationBL.Trackingchart(parameters, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult MigrateProtocolToSIGESoftWin(QuotationMigrateDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _quotationBL.MigrateProtocolToSIGESoftWin(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}