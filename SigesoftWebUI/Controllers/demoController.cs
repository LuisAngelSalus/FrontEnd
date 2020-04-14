using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class demoController : Controller
    {
        // GET: demo
        public ActionResult Index()
        {
            return View();
        }

        // GET: demo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: demo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: demo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: demo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: demo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: demo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: demo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
