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
    public class RoleController : GenericController
    {
        RoleBL _roleBL = new RoleBL();
        SecurityBL _securityBL = new SecurityBL();
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