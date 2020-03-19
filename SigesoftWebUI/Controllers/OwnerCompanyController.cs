using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class OwnerCompanyController : GenericController
    {
        private OwnerCompanyBL _ownerCompanyBL = new OwnerCompanyBL();
        private SecurityBL _securityBL = new SecurityBL();

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