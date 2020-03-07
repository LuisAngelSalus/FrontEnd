using BE;
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
    public class CustomerController : GenericController
    {
        CompanyBL _companyBL = new CompanyBL();
        ClientUserBL _clientUserBL = new ClientUserBL();
        SecurityBL _securityBL = new SecurityBL();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyData()
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _companyBL.CompanyDetail(sessione.CustomerCompanyId.Value, validated.Token);
            ViewBag.Detail = response.Data;

            var clientUsers = _clientUserBL.GetAllAsyncByCompany(sessione.CustomerCompanyId.Value, validated.Token);
            ViewBag.CLIENTUSERS = clientUsers.Data;
            return View();
        }
    }
}