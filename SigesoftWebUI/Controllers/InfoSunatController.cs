using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class InfoSunatController : Controller
    {
        InfoSunatBL _infoSunatBL = new InfoSunatBL();
        // GET: InfoSunat
        public JsonResult Info(string ruc)
        {
            var response = _infoSunatBL.info(ruc);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}