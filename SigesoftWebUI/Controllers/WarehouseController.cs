using BE;
using SigesoftWebUI.Controllers.Base;
using SigesoftWebUI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SigesoftWebUI.Controllers
{
    public class WarehouseController : GenericController
    {
        WarehouseRepository warehouseRepository;

        public WarehouseController()
        {
            warehouseRepository = new WarehouseRepository();
        }

        // GET: Warehouse
        public ActionResult Index()
        {
            List<WarehouseDto> response;
            response = warehouseRepository.GetAll(SessionUsuario).Data;
            return View(response);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(WarehouseDto warehouseDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(warehouseDto);
                }
                else
                {
                    var response = warehouseRepository.Post(warehouseDto, SessionUsuario);
                    if (response.IsSuccess)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var response = warehouseRepository.GetById(id, SessionUsuario);
            if (response.IsSuccess)
            {
                return View(response.Data);
            }
            return View();
        }


        [HttpPost]
        public ActionResult Edit(WarehouseDto warehouseDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(warehouseDto);
                }
                else
                {
                    var response = warehouseRepository.Put(warehouseDto, SessionUsuario);
                    if (response.IsSuccess)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var response = warehouseRepository.GetById(id, SessionUsuario);
            if (response.IsSuccess)
            {
                return View(response.Data);
            }
            return View();
        }


        // POST: demo/Delete/5
        [HttpPost]        
        public ActionResult Delete(int id, WarehouseDto warehouseDto)
        {
            try
            {
                var response = warehouseRepository.Delete(id, SessionUsuario);
                if (response.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}