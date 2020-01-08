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
    public class SecuentialController : Controller
    {
        SecuentialBL _SecuentialBL = new SecuentialBL();
        public JsonResult GetSecuential(SecuentialDto data)
        {
            var response = _SecuentialBL.GetSecuential(data);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}