using BE;
using BL;
using SigesoftWebUI.Models;
using SigesoftWebUI.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SigesoftWebUI.Controllers
{
    public class IngresoSistemaController : Controller
    {
        SecurityBL _securityBL = new SecurityBL();

        // GET: IngresoSistema
        [AllowAnonymous]

        public ActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl = null)
        {
            try
            {
                var oLoginDto = new LoginDto();
                oLoginDto.v_UserName = model.Username;
                oLoginDto.v_Password = model.Password;

                var result = _securityBL.ValidateAccess(oLoginDto);

                if (result != null)
                {
                    var sessionModel = new SessionModel();
                    var token = result.Token;

                    sessionModel = _securityBL.UserAccess(result.SystemUserId, token);

                    //sessionModel.SystemUserId = dataUser.SystemUserId;
                    //sessionModel.FullName = dataUser.FullName;
                    //sessionModel.UserName = dataUser.UserName;
                    sessionModel.Pass = oLoginDto.v_Password;

                    FormsAuthentication.SetAuthCookie(sessionModel.UserName, false);

                    HttpSessionContext.SetAccount(sessionModel);
                }
                else
                {
                    ModelState.AddModelError("", "Contraseña o identificador de usuario incorrectos. Escriba la contraseña y el identificador de usuario correctos e inténtelo de nuevo.");
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al procesar la solicitud.");
                return RedirectToAction("Login", "IngresoSistema");
            }

            return RedirectToLocal(returnUrl);
        }

        [AllowAnonymous]
        public ActionResult UserUnknown()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogOff()
        {
            return CerrarSesion();
        }

        private ActionResult CerrarSesion()
        {
            var rolUsuario = string.Empty;
            var userData = HttpSessionContext.CurrentAccount();
            if (userData != null)
            {
                rolUsuario = userData.UserName;
            }

            var urlSignOut = string.Empty;

            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Session.Clear();


            urlSignOut = string.Format("{0}", System.Web.Security.FormsAuthentication.LoginUrl);


            return Redirect(urlSignOut);
        }


        [AllowAnonymous]
        public ActionResult SesionExpirada(string returnUrl)
        {
            AsignarUrlRetorno(returnUrl);
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Generals");
        }

        protected virtual void AsignarUrlRetorno(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null)
                returnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);

            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnURL = returnUrl;
            }
        }

    }
}