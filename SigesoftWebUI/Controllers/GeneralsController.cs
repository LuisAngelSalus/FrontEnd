using BE;
using SigesoftWebUI.Controllers.Base;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class GeneralsController : GenericController
    {
        // GET: Generals
        public ActionResult Index()
        {
            @ViewBag.DATAUSER = ((ClientSession)Session["AutSigesoftWebUI"]);
            return View();
        }

        public ActionResult home()
        {            
            return View();
        }

      
    }
}