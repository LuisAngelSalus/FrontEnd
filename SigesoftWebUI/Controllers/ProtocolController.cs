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
    public class ProtocolController : GenericController
    {
        ProtocolBL _protocolBL = new ProtocolBL();
        SecurityBL _securityBL = new SecurityBL();

        // GET: Protocol
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProtocolsByCompany(int id)
        {


            var response = _protocolBL.GetProtocolsByCompanyId(id, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

    }
}