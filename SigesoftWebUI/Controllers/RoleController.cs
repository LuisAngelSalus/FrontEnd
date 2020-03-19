using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class RoleController : GenericController
    {
        private RoleBL _roleBL = new RoleBL();
        private SecurityBL _securityBL = new SecurityBL();

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Roles()
        {
            var response = _roleBL.Roles(SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}