using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using SigesoftWebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion
            var oParamsCompanyFilterModel = new ParamsCompanyFilterModel();
            oParamsCompanyFilterModel.ResponsibleSystemUserId = validated.SystemUserId;
            var response = _companyBL.Companies(oParamsCompanyFilterModel,validated.Token);
            if (response.IsSuccess)
            {
                ViewBag.data = response.Data;
            }
                        

            return View();
        }

        public ActionResult Detail(int id)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            if (id == 0)
            {
                ViewBag.Detail = new Models.ModelCompanyDetail();
            }
            else
            {

                var response = _companyBL.CompanyDetail(id, validated.Token);
                ViewBag.Detail = response.Data;
            }
            
            return View();
        }

        public JsonResult Save(CompanyDetailDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            if (Request.Files.Count > 0)
            {

            }

            data.ResponsibleSystemUserId = validated.SystemUserId;
            data.InsertUserId = validated.SystemUserId;

            data.PathLogo = data.IdentificationNumber;
            var response = _companyBL.Save(data, validated.Token);
            //if (response.IsSuccess)
            //{
                SaveImage(data.ImageLogo,data.IdentificationNumber);
            //}
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
     
        public JsonResult Contacts(int companyId)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _companyBL.Contacts(companyId, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
             
        }

        public JsonResult CompanyByRuc(string ruc)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _companyBL.CompanyByRuc(ruc, validated.Token);

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteByName(string value)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _companyBL.AutocompleteByName(value,validated.Token);        

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateUserCompany(string ruc)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _companyBL.ValidateUserCompany(validated.SystemUserId, ruc, validated.Token);

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        private void SaveImage(string imagebase64, string name)
        {
            var path = Server.MapPath(@"~\Content\LogosCompany\")+name + ".png";            
            if (imagebase64 == null)
            {                
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);                
            }
            else
            {
                byte[] bytes = Convert.FromBase64String(imagebase64);                
                System.IO.File.WriteAllBytes(path, bytes);
            }
        }
    }
}