using BL;
using SigesoftWebUI.Controllers.Base;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class CustomerController : GenericController
    {
        private CompanyBL _companyBL = new CompanyBL();
        private ClientUserBL _clientUserBL = new ClientUserBL();
        private SecurityBL _securityBL = new SecurityBL();

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