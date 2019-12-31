using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Views.Organization
{
    public class CompanyController : Controller
    {
        CompanyBL _companyBL = new CompanyBL();

        public ActionResult Index()
        {
           var response = _companyBL.Companies();
            if (response.IsSuccess)
            {
                ViewBag.data = response.Data;
                //return View(response.Data);
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            if (id == 0)
            {
                ViewBag.Detail = new Models.ModelCompanyDetail();
            }
            else
            {
                var response = _companyBL.CompanyDetail(id);
                ViewBag.Detail = response.Data;
            }
            
            return View();
        }

        public JsonResult Save(CompanyDetailDto data)
        {
            var response = _companyBL.Save(data);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Contacts(int companyId)
        {
            var response = _companyBL.Contacts(companyId);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
             
        }
    }
}