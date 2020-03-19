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
    public class PersonController : GenericController
    {
        SecurityBL _securityBL = new SecurityBL();
        PersonBL _personBL = new PersonBL();
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPerson(int personId)
        {
          

            var response = _personBL.GetPerson(personId, SessionUsuario.Token);
          

            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(PersonRegistertDto data)
        {
         

            var response = _personBL.Save(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(PersonUpdateDto data)
        {
            

            var response = _personBL.Update(data, SessionUsuario.Token);
            return Json(response, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}