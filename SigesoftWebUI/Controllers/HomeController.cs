using SigesoftWebUI.Controllers.Base;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class HomeController : GenericController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}