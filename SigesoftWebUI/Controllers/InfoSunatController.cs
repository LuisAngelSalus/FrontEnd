using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class InfoSunatController : GenericController
    {
        private InfoSunatBL _infoSunatBL = new InfoSunatBL();
        private SecurityBL _securityBL = new SecurityBL();

        // GET: InfoSunat
        public JsonResult Info(string ruc)
        {
            var response = _infoSunatBL.info(ruc, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}