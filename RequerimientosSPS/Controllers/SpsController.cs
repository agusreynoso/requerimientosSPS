using RequerimientosSPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RequerimientosSPS.Controllers
{
    public class SpsController : Controller
    {
        private spsrequerimientosEntities db = new spsrequerimientosEntities();
        // GET: Sps
        public ActionResult Index()
        {
            var sps = db.sps.OrderByDescending(n => n.vuser).ToList();
            ViewBag.cumplidas = db.sps.Where(a => a.estadoSps.descripcion == "SPSCerrada").Count();
            ViewBag.pendientes = db.sps.Where(a => a.estadoSps.descripcion != "SPSCerrada").Count();
            return View(sps);
        }

        // GET: Sps/Details/5
        public ActionResult Details(int id)
        {
            var sps = db.sps.Where(n => n.Id == id);
            return View(sps);
        }

        // GET: Sps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sps/Create
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

        // GET: Sps/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sps/Edit/5
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

        // GET: Sps/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sps/Delete/5
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
