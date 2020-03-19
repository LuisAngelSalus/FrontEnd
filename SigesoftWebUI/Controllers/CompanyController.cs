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

namespace SigesoftWebUI.Views.Organization
{
    public class CompanyController : GenericController
    {
        CompanyBL _companyBL = new CompanyBL();
        SecurityBL _securityBL = new SecurityBL();
        public ActionResult Index()
        {

            var oParamsCompanyFilterModel = new ParamsCompanyFilterModel();
            oParamsCompanyFilterModel.ResponsibleSystemUserId = SessionUsuario.SystemUserId;
            var response = _companyBL.Companies(oParamsCompanyFilterModel, SessionUsuario.Token);
            if (response.IsSuccess)
            {
                ViewBag.data = response.Data;
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
                var response = _companyBL.CompanyDetail(id, SessionUsuario.Token);
                ViewBag.Detail = response.Data;
            }

            return View();
        }

        public JsonResult Save(CompanyDetailDto data)
        {
 

            data.ResponsibleSystemUserId = SessionUsuario.SystemUserId;
            data.InsertUserId = SessionUsuario.SystemUserId;
            var response = _companyBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Contacts(int companyId)
        {
           

            var response = _companyBL.Contacts(companyId, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult CompanyByRuc(string ruc)
        {
           

            var response = _companyBL.CompanyByRuc(ruc, SessionUsuario.Token);

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteByName(string value)
        {
         

            var response = _companyBL.AutocompleteByName(value, SessionUsuario.Token);

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }


    }
}