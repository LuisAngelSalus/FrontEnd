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
    public class ProtocolProfileController : GenericController
    {
        ProtocolProfileBL _protocolProfileBL = new ProtocolProfileBL();
        SecurityBL _securityBL = new SecurityBL();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(ProtocolProfileRegisterDto entity)
        {


            var response = _protocolProfileBL.Save(entity, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DropdownList()
        {


            var response = _protocolProfileBL.DropdownList(SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Autocomplete(string value)
        {


            var response = _protocolProfileBL.Autocomplete(value, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

    }
}