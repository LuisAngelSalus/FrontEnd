using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class AccountSettingController : GenericController
    {
        private AccountSettingBL _accountSettingBL = new AccountSettingBL();
        private SecurityBL _securityBL = new SecurityBL();

        // GET: AccountSetting
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAccountSettingBySystemUserId()
        {
            var response = _accountSettingBL.GetAccountSettingBySystemUserId(SessionUsuario.SystemUserId, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(AccountSettingRegisterDto data)
        {
            data.SystemUserId = SessionUsuario.SystemUserId;
            data.InsertUserId = SessionUsuario.SystemUserId;
            var response = _accountSettingBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(AccountSettingUpdateDto data)
        {
            data.SystemUserId = SessionUsuario.SystemUserId;
            data.UpdateUserId = SessionUsuario.SystemUserId;
            var response = _accountSettingBL.Update(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}