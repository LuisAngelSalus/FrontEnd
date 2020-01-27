﻿using BE;
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

namespace SigesoftWebUI.Controllers
{
    public class QuotationController : GenericController
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

        public JsonResult GetQuotation(int id)
        {
            var response = _quotationBL.GetQuotation(id);
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

        public JsonResult GetVersions(string code)
        {
            var response = _quotationBL.GetVersions(code);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        //public FileResult GetDocumentPDF(string data)
        //{

        //    byte[] byteArray;
        //    RootObject deserializeQuotation = JsonConvert.DeserializeObject<RootObject>(data);
        //    using (MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        StringReader sr = new StringReader(data);
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
        //        pdfDoc.Open();
        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //        pdfDoc.Close();
        //        return File(stream.ToArray(), "application/pdf", "Grid.pdf");
        //    }
        //}

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
            var response = _quotationBL.UpdateProccess(data);
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

        public ActionResult ExportPlantilla(int code)
        {
            var response = _quotationBL.GetQuotation(code);


            string path = Path.Combine(HttpRuntime.AppDomainAppPath, "Template");


            using (MemoryStream memoryStreamRead = new MemoryStream())
            {
                Document document = new Document();
                document.LoadFromFile(path + "/PLANTILLA_PROPUESTA_COMERCIAL.docx");
                document.Replace("@COTI", response.Data.QuotationId.ToString(), false, true);
                document.Replace("@VER", response.Data.Version.ToString(), false, true);
                document.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"), false, true);
                document.Replace("@EMPRESA", response.Data.CompanyName.ToString(), false, true);

                document.SaveToStream(memoryStreamRead, FileFormat.PDF);

                MemoryStream workbook = memoryStreamRead;
                string saveAsFileName = "PLANTILLA_PROPUESTA_COMERCIAL" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".pdf";
                //return File(workbook.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", string.Format("{0}", saveAsFileName));
                return File(workbook.ToArray(), "application/pdf", string.Format("{0}", saveAsFileName));
            }

            //Document doc = new Document(PageSize.Letter);
            //FileStream file = new FileStream("Propuesta comercial.pdf", FileMode.Create);
            //PdfWriter writer = PdfWriter.GetInstance(doc, file);

            //doc.AddAuthor("SalusLaboris");
            //doc.AddTitle("Propuesta Comercial");
            //doc.Open();

            //doc.Add(new Phrase("Por medio de la presente, reciban un cordial saludo a nombre de SALUS LABORIS\n S.A.C. Somos una empresa que brinda servicios integrales de Salud Ocupacional y \nRespuesta a Emergencias con más de 12 años de experiencia en el mercado."));
            //writer.Close();
            //doc.Close();

            //var pdf = new FileStream("Propuesta comercial.pdf", FileMode.Open, FileAccess.Read);
            //return File(pdf, "aplication/pdf");
        }
    }
}