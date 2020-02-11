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
    public class ProtocolDetailController : Controller
    {
        ProtocolDetailBL _protocolDetailBL = new ProtocolDetailBL();
        SecurityBL _securityBL = new SecurityBL();
        // GET: ProtocolDetail
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProtocolDetailByProtocol(int id)
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            var response = _protocolDetailBL.GetProtocolDetailByProtocolId(id, validated.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}