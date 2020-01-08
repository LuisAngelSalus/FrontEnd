using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Utils;

namespace SigesoftWebUI.Controllers
{
    public class QuotationController : Controller
    {
        QuotationBL _quotationBL = new QuotationBL();

        public ActionResult Index()
        {
            return View();
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
                var oGenerateCode    = new GenerateCode();
                var oQuotationDto = new QuotationDto();
                //var code = "el nro de cotización se generará al grabar la cotización"; 
                //oGenerateCode.Code("COT","PAT",1);
                //oQuotationDto.Code = code;
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
    }
}