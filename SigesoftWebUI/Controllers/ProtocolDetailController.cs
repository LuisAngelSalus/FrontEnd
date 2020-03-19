using BE;
using BL;
using SigesoftWebUI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ProtocolDetailController : GenericController
    {
        ProtocolDetailBL _protocolDetailBL = new ProtocolDetailBL();
        SecurityBL _securityBL = new SecurityBL();
        // GET: ProtocolDetail
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProtocolDetailByProtocol(int id)
        {
       
            var response = _protocolDetailBL.GetProtocolDetailByProtocolId(id, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}