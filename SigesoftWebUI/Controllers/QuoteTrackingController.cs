using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class QuoteTrackingController : Controller
    {
        QuoteTrackingBL _quoteTrackingBL = new QuoteTrackingBL();

        public JsonResult Save(QuoteTrackingRegisterDto data)
        {
            var response = _quoteTrackingBL.Save(data);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}