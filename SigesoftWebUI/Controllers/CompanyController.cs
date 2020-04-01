using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using SigesoftWebUI.Repositories;
using SigesoftWebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utils;

namespace SigesoftWebUI.Views.Organization
{
    public class CompanyController : GenericController
    {
        private readonly CompanyRepository companyRepository = new CompanyRepository();

        private CompanyBL _companyBL = new CompanyBL();
        private SecurityBL _securityBL = new SecurityBL();

        public ActionResult Index()
        {
            ParamsCompanyFilterModel paramsCompanyFilterModel = new ParamsCompanyFilterModel();
            paramsCompanyFilterModel.ResponsibleSystemUserId = SessionUsuario.SystemUserId;

            IEnumerable<ListCompanyDto> listCompanyDtos = null;

            var response = companyRepository.Companies(paramsCompanyFilterModel, SessionUsuario);

            if (response.IsSuccess)
            {
                listCompanyDtos = response.Data;
            }

            return View(listCompanyDtos);
        }

        public ActionResult Detail(int id)
        {
            CompanyViewModel companyViewModel = null;

            if (id != 0)
            {
                var response = companyRepository.CompanyDetail(id, SessionUsuario);
                if (response.IsSuccess)
                {
                    companyViewModel = response.Data;
                }
            }

            return View(companyViewModel);
        }

        [HttpPost]
        public ActionResult Save(CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View("Detail", companyViewModel);
        }

        //public JsonResult Save(CompanyDetailDto data)
        //{
        //    data.ResponsibleSystemUserId = SessionUsuario.SystemUserId;
        //    data.InsertUserId = SessionUsuario.SystemUserId;
        //    var response = _companyBL.Save(data, SessionUsuario.Token);
        //    if (Request.Files.Count > 0)
        //    {

        //    }


        //    data.PathLogo = data.IdentificationNumber;
        //    //if (response.IsSuccess)
        //    //{
        //        SaveImage(data.ImageLogo,data.IdentificationNumber);
        //    //}
        //    return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Contacts(int companyId)
        //{
        //    var response = _companyBL.Contacts(companyId, SessionUsuario.Token);
        //    return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Contacts(int id)
        {
            var response = _companyBL.Contacts(id, SessionUsuario.Token).Data;
            return PartialView("Contacts", response);
        }

        public JsonResult ValidateUserCompany(string ruc)
        {
            var response = _companyBL.ValidateUserCompany(validated.SystemUserId, ruc, validated.Token);

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}