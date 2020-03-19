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
    public class SuscriptionController : GenericController
    {
        SuscriptionBL _suscriptionBL = new SuscriptionBL();
        SecurityBL _securityBL = new SecurityBL();
        public JsonResult GetKeyPublic()
        {
          

            var response = _suscriptionBL.GetKeyPublic(SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(SuscriptionRegisterDto data)
        {
          

            data.SystemUserId = SessionUsuario.SystemUserId;
            var response = _suscriptionBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Push(SuscriptionPushDto data)
        {
   
                        
            var response = _suscriptionBL.Push(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}