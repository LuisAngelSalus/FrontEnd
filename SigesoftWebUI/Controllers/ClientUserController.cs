using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ClientUserController : GenericController
    {
        private ClientUserBL _clientUserBL = new ClientUserBL();
        private SecurityBL _securityBL = new SecurityBL();

        // GET: ClientUser
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetById(int clientUserId)
        {
            var response = _clientUserBL.GetById(clientUserId, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClientsUsersForCompany()
        {
            var response = _clientUserBL.GetAllAsyncByCompany(SessionUsuario.CustomerCompanyId.Value, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(ClientUserRegisterDto data)
        {
            data.CompanyId = SessionUsuario.CustomerCompanyId.Value;
            data.InsertUserId = SessionUsuario.SystemUserId;
            var response = _clientUserBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ClientUserUpdateDto data)
        {
            data.UpdateUserId = SessionUsuario.SystemUserId;
            var response = _clientUserBL.Update(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangePassword(ClientUserPasswordDto data)
        {
            data.UpdateUserId = SessionUsuario.SystemUserId;
            var response = _clientUserBL.ChangePassword(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCompany(CompanyDetailDto data, string token)
        {
            data.ResponsibleSystemUserId = SessionUsuario.SystemUserId;
            data.InsertUserId = SessionUsuario.SystemUserId;
            var response = _clientUserBL.UpdateCompany(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}