using BE;
using BL;
using Newtonsoft.Json;
using SigesoftWebUI.Controllers.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class ScheduleController : GenericController
    {
        SecurityBL _securityBL = new SecurityBL();
        ScheduleBL _scheduleBL = new ScheduleBL();
        // GET: Schedule
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            #region TOKEN
            var sessione = (SessionModel)Session[Resources.Constante.SessionUsuario];
            LoginDto oLoginDto = new LoginDto();
            oLoginDto.v_UserName = sessione.UserName;
            oLoginDto.v_Password = sessione.Pass;
            var validated = _securityBL.ValidateAccess(oLoginDto);
            if (validated == null) return Json("", "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
            #endregion

            byte[] arr = null;

            using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
            {
                arr = binaryReader.ReadBytes(Request.Files[0].ContentLength);
            }

           var result =  _scheduleBL.Read(arr, validated.Token);

            return Json(result);
        }
    }
}