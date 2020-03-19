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

            var response = _companyBL.CompanyDetail(SessionUsuario.CustomerCompanyId.Value, SessionUsuario.Token);
            ViewBag.Detail = response.Data;

            var clientUsers = _clientUserBL.GetAllAsyncByCompany(SessionUsuario.CustomerCompanyId.Value, SessionUsuario.Token);
            ViewBag.CLIENTUSERS = clientUsers.Data;
            return View();
        }
    }
}