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

namespace SigesoftWebUI.Controllers
{
    public class QuotationController : Controller
    {
        QuotationBL _quotationBL = new QuotationBL();
        

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Filter(ParamsQuotationFilterDto parameters)
        {
            var response = _quotationBL.Filter(parameters);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Register(int id)
        {
            var response = _quotationBL.GetQuotation(id);
            if (response != null)
            {
                ViewBag.DataQuotation = response.Data;
            }
            else
            {
                var oQuotationDto = new QuotationDto();
                ViewBag.DataQuotation = oQuotationDto;
            }
            return View();
        }

        public JsonResult GetProfile(int profileId)
        {
            var response = _quotationBL.GetProfile(profileId);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Save(QuotationRegisterDto data)
        {
             var response = _quotationBL.Save(data);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult NewVersion(QuotationNewVersionDto data)
        {
            var response = _quotationBL.NewVersion(data);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(QuotationUpdateDto data)
        {
            var response = _quotationBL.Update(data);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetComponents()
        {
            var response = _quotationBL.GetComponents();
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public FileResult GetHTMLPageAsPDF()
        {
            var Renderer = new IronPdf.HtmlToPdf();
            var PDF = Renderer.RenderHtmlAsPdf(Generator.GetHTMLString());
            var contentLength = PDF.BinaryData.Length;
            Response.AppendHeader("Content-Length", contentLength.ToString());
            Response.AppendHeader("Content-Disposition", "inline; filename=Document_" + "demo" + ".pdf");
            return File(PDF.BinaryData, "application/pdf;");
        }
        
    }
}