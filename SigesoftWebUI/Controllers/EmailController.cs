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
    public class EmailController : GenericController
    {
        EmailBL _emailBL = new EmailBL();
        public JsonResult SendMail(EmailDto data)
        {
            _emailBL.SendMail(data);
            var response = "ok";
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}