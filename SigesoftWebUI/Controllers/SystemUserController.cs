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
            
            var data = _securityBL.UserAccess(id, SessionUsuario.Token);
            ViewBag.UserAccess = data == null ? new SessionModel() : data;
            return View();
        }

        public JsonResult GetAllSystemUser()
        {
         
            var response = _securityBL.GetAllSystemUser(SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUser(int userId)
        {
          
            
            var response = _securityBL.GetSystemUser(userId,SessionUsuario.Token);
           

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(SystemUserRegisterDto data)
        {
           

            var response = _securityBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(SystemUserUpdateDataDto data)
        {
           

            var response = _securityBL.Update(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult SaveAccess(List<RegisterAccessDto> data)
        {
           
            //ADD USER AUDIT
            foreach (var item in data)
            {
                item.UpdateUserId = SessionUsuario.SystemUserId;
            }

            var response = _securityBL.SaveAccess(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}