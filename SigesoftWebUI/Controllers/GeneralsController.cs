using BE;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class GeneralsController : GenericController
    {
        // GET: Generals
        public ActionResult Index(string roleId)
        {
            var response = (SessionModel)Session[Resources.Constante.SessionUsuario];
            ViewBag.UserData = response.UserName + "|" + roleId;
            ViewBag.UserData =  roleId;
            return View();                    
        }

        public PartialViewResult Dashboard(string roleId)
        {            
            if (roleId == "1")
            {
                return PartialView("_DashboardSistemasPartial");
            }
            else if(roleId == "5") 
            {
                return PartialView("_DashboardCommercialPartial");
            }
            else
            {
                return PartialView("_DashboardEmptyPartial");
            }

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