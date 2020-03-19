using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class SecuentialController : GenericController
    {
        private SecuentialBL _SecuentialBL = new SecuentialBL();
        private SecurityBL _securityBL = new SecurityBL();

        public JsonResult GetSecuential(SecuentialDto data)
        {
            var response = _SecuentialBL.GetSecuential(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}