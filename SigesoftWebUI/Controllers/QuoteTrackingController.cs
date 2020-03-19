using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class QuoteTrackingController : GenericController
    {
        private QuoteTrackingBL _quoteTrackingBL = new QuoteTrackingBL();
        private SecurityBL _securityBL = new SecurityBL();

        public JsonResult Save(QuoteTrackingRegisterDto data)
        {
            var response = _quoteTrackingBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(QuoteTrackingUpdateDto data)
        {
            var response = _quoteTrackingBL.Update(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuoteTracking(int id)
        {
            var response = _quoteTrackingBL.GetQuoteTracking(id, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}