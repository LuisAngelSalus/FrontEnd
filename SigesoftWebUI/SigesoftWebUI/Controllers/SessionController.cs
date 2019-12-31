using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utils;

namespace SigesoftWebUI.Controllers
{
    public class SessionController : Controller
    {
        SecurityBL _securityBL = new SecurityBL();
        public ActionResult LoginAuthentication(FormCollection collection)
        {
            if (TempData["FormCollection"] != null)
                collection = (FormCollection)TempData["FormCollection"];

            if (collection.Get("username").Trim() != string.Empty && collection.Get("password").Trim() != string.Empty)
            {
                TempData["FormCollection"] = null;

                var oLoginDto = new LoginDto();
                oLoginDto.v_UserName = collection.Get("username").Trim();
                oLoginDto.v_Password = collection.Get("password").Trim();

                var result = _securityBL.ValidateAccess(oLoginDto);

                if (result !=null)
                {                    
                   var dataUser = _securityBL.UserAccess(result.SystemUserId);                    
                    Session.Add("AutSigesoftWebUI", dataUser);
                    return RedirectToRoute("Sigesoft");
                }               
            }
            else
            {
                TempData["MESSAGE"] = "Debe ingresar el username y la contraseña";
            }
            return RedirectToRoute("General_Login");
        }


    }
}