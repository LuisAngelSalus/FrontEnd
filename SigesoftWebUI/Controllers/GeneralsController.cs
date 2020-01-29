using BE;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class GeneralsController : GenericController
    {
        // GET: Generals
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult home()
        {            
            return View();
        }


        public JsonResult GetAccess()
        {
            var response = (SessionModel)Session[Resources.Constante.SessionUsuario];
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }


    }
}