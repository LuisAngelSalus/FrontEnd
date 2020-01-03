using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class QuotationController : Controller
    {
        QuotationBL _quotationBL = new QuotationBL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterQuotation(int id)
        {
            var response = _quotationBL.GetQuotation(id);
            if (response != null)
            {
                ViewBag.DataQuotation = response.Data;
            }
            return View();
        }

        public JsonResult GetProfile(int profileId)
        {
            var response = _quotationBL.GetProfile(profileId);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}