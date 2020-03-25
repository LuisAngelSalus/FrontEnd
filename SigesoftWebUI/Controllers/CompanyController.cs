using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SigesoftWebUI.Views.Organization
{
    public class CompanyController : GenericController
    {
        private CompanyBL _companyBL = new CompanyBL();
        private SecurityBL _securityBL = new SecurityBL();

        public ActionResult Index()
        {
            var oParamsCompanyFilterModel = new ParamsCompanyFilterModel();
            oParamsCompanyFilterModel.ResponsibleSystemUserId = SessionUsuario.SystemUserId;
            var response = _companyBL.Companies(oParamsCompanyFilterModel, SessionUsuario.Token).Data;

            return View(response);
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
            if (Request.Files.Count > 0)
            {

            }

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public JsonResult UploadLogoCompany(int id)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var fileName = Path.GetFileName(file);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }

            return Json("File uploaded successfully");
        }

        //public JsonResult Contacts(int companyId)
        //{
        //    var response = _companyBL.Contacts(companyId, SessionUsuario.Token);
        //    return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Contacts(int id )
        {
            var response = _companyBL.Contacts(id, SessionUsuario.Token).Data;
            return PartialView("Contacts", response);
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
        public JsonResult ValidateUserCompany(string ruc)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            //oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _companyBL.ValidateUserCompany(validated.SystemUserId, ruc, validated.Token);

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}