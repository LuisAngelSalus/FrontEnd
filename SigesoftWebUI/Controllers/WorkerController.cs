using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System.Text;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class WorkerController : GenericController
    {
        private WorkerBL _workerBL = new WorkerBL();
        private SecurityBL _securityBL = new SecurityBL();

        // GET: Worker
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDataWorker()
        {
            var response = _workerBL.GetDataWorker(SessionUsuario.SystemUserId, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateWorkerData(WorkerDto data)
        {
            var response = _workerBL.UpdateWorkerData(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}