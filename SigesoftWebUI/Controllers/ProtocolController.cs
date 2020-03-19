using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ProtocolController : GenericController
    {
        private ProtocolBL _protocolBL = new ProtocolBL();
        private SecurityBL _securityBL = new SecurityBL();

        // GET: Protocol
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProtocolsByCompany(int id)
        {
            var response = _protocolBL.GetProtocolsByCompanyId(id, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}