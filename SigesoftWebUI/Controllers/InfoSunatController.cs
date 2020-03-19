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
    public class InfoSunatController : GenericController
    {
        InfoSunatBL _infoSunatBL = new InfoSunatBL();
        SecurityBL _securityBL = new SecurityBL();
        // GET: InfoSunat
        public JsonResult Info(string ruc)
        {
          

            var response = _infoSunatBL.info(ruc, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}