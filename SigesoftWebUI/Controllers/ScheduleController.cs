using BL;
using SigesoftWebUI.Controllers.Base;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ScheduleController : GenericController
    {
        private SecurityBL _securityBL = new SecurityBL();
        private ScheduleBL _scheduleBL = new ScheduleBL();
        private ProtocolBL _protocolBL = new ProtocolBL();

        public ActionResult Register()
        {
            ViewBag.PROTOCOLS = _protocolBL.GetProtocolsByCompanyId(SessionUsuario.CustomerCompanyId.Value, SessionUsuario.Token);
            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            byte[] arr = null;

            using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
            {
                arr = binaryReader.ReadBytes(Request.Files[0].ContentLength);
            }

            var result = _scheduleBL.Read(arr, SessionUsuario.Token);

            return Json(result);
        }

        public JsonResult GetComponentsByName(string value)
        {
            var response = _scheduleBL.GetByName(value, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAdditionalComponents(int protocolId)
        {
            var response = _scheduleBL.GetAdditionalComponents(protocolId, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}