using OWINSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWINSample.Controllers
{
    public class MapsController : Controller
    {
        // GET: Maps
        public ActionResult Index()
        {
            var model = new MapsModel { MapsKey = "AkdTDUUzA1xA27bQiYIqsLFLBUPUrfpGY6SxbNQ70kdVua0HomPyx0b6dmjaygE9" };
            return View(model);
        }

        // GET: Maps/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Maps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maps/Create
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

        // GET: Maps/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Maps/Edit/5
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

        // GET: Maps/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Maps/Delete/5
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
