﻿using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ProtocolProfileController : Controller
    {
        ProtocolProfileBL _protocolProfileBL = new ProtocolProfileBL();
                
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Save(ProtocolProfileRegisterDto entity)
        {
            var response = _protocolProfileBL.Save(entity);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DropdownList()
        {
            var response = _protocolProfileBL.DropdownList();
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Autocomplete(string value)
        {
            var response = _protocolProfileBL.Autocomplete(value);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
        
    }
}