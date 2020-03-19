using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using SigesoftWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class SecuentialController : GenericController
    {
        SecuentialBL _SecuentialBL = new SecuentialBL();
        SecurityBL _securityBL = new SecurityBL();
        public JsonResult GetSecuential(SecuentialDto data)
        {


            var response = _SecuentialBL.GetSecuential(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}