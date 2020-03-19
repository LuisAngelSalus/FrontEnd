﻿using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class OwnerCompanyController : GenericController
    {
        OwnerCompanyBL _ownerCompanyBL = new OwnerCompanyBL();
        SecurityBL _securityBL = new SecurityBL();
        // GET: OwnerCompany
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
         
            var response = _ownerCompanyBL.OwnerCompanies(SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}