using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class AccountSettingController : Controller
    {
        AccountSettingBL _accountSettingBL = new AccountSettingBL();
        SecurityBL _securityBL = new SecurityBL();
        // GET: AccountSetting
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAccountSettingBySystemUserId()
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _accountSettingBL.GetAccountSettingBySystemUserId(validated.SystemUserId, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(AccountSettingRegisterDto  data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            data.SystemUserId = validated.SystemUserId;
            data.InsertUserId = validated.SystemUserId;
            var response = _accountSettingBL.Save(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(AccountSettingUpdateDto data)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            data.SystemUserId = validated.SystemUserId;
            data.UpdateUserId= validated.SystemUserId;
            var response = _accountSettingBL.Update(data, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

    }
}