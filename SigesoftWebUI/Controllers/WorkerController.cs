using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using SigesoftWebUI.Controllers.Base;

namespace SigesoftWebUI.Controllers
{
    public class WorkerController : GenericController
    {
        WorkerBL _workerBL = new WorkerBL();
        SecurityBL _securityBL = new SecurityBL();

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