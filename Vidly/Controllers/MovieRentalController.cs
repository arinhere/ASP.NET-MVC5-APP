using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class MovieRentalController : Controller
    {
        // GET: MovieRental
        public ActionResult CreateRental()
        {
            return View();
        }

        // GET: MovieRental/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieRental/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieRental/Create
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

        // GET: MovieRental/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieRental/Edit/5
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

        // GET: MovieRental/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieRental/Delete/5
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
