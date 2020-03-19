using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ProtocolDetailController : GenericController
    {
        private ProtocolDetailBL _protocolDetailBL = new ProtocolDetailBL();
        private SecurityBL _securityBL = new SecurityBL();

        // GET: ProtocolDetail
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProtocolDetailByProtocol(int id)
        {
            var response = _protocolDetailBL.GetProtocolDetailByProtocolId(id, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}