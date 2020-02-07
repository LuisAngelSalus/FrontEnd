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
    public class SystemUserController : GenericController
    {
        SecurityBL _securityBL = new SecurityBL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(int id)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            ViewBag.UserAccess = _securityBL.UserAccess(id, validated.Token);
            return View();
        }

        public JsonResult GetAllSystemUser()
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion
            var response = _securityBL.GetAllSystemUser(validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUser(int userId)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            
            var response = _securityBL.GetSystemUser(userId,validated.Token);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}