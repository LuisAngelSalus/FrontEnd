using BE;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class GeneralsController : Controller
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

        public ActionResult Login()
        {
            if (TempData["MESSAGE"] != null)
            {
                ViewBag.MESSAGE = TempData["MESSAGE"];
            }
            return View("~/Views/Generals/Login.cshtml");
        }

        public ActionResult Logout()
        {
            Session.Remove("AutSigesoftWebUI");
            Session.RemoveAll();
            return RedirectToRoute("General_login");
        }

        public ActionResult Notauthorized()
        {
            return RedirectToAction("Sigesoft");
        }

        public ActionResult SessionExpired()
        {
            Session.Remove("AutSigesoftWebUI");
            Session.RemoveAll();
            return RedirectToRoute("General_login");
        }

     
        //public ActionResult Home()
        //{
        //    return View("~/Views/Generals/Index.cshtml", ViewBag.MENU);
        //}

        //public static string GetPost(string url)
        //{
        //    var result = "";
        //    WebRequest oRequest = WebRequest.Create(url);
        //    oRequest.Method = "POST";
        //    oRequest.ContentType = "application/json;charset=UTF-8";

        //    using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
        //    {
        //        string json = "{\"v_UserName\": \"luis.sistemas\",\"v_Password\": \"123456\"}";
        //        oSW.Write(json);
        //        oSW.Flush();
        //        oSW.Close();
        //    }

        //    WebResponse oResponse = oRequest.GetResponse();
        //    using(var oSR = new StreamReader(oResponse.GetResponseStream()))
        //    {
        //        result = oSR.ReadToEnd().Trim();
        //    }
        //    return result;

        //}
    }
}