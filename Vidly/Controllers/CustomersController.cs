using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db;

        public CustomersController()
        {
            db=new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var cus = from x in db.Customers where x.Id== id select x; THIS IS CORRECT
            //var customers = db.Customers.Where(c => c.Id == id); THIS IS CORRECT
            Customers customers = db.Customers.Find(id);
            
            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.MembershipTypeId = new SelectList(db.Memberships, "Id", "MembershipType");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerName,IsSubscribedToNewsletter,MembershipTypeId")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MembershipTypeId = new SelectList(db.Memberships, "Id", "MembershipType", customers.MembershipTypeId);
            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.MembershipTypeId = new SelectList(db.Memberships, "Id", "MembershipType", customers.MembershipTypeId);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customers customers)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = db.Customers.Single(c => c.Id == customers.Id);
                customerInDb.BirthDate = customers.BirthDate;
                customerInDb.CustomerName = customers.CustomerName;
                customerInDb.IsSubscribedToNewsletter = customers.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customers.MembershipTypeId;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MembershipTypeId = new SelectList(db.Memberships, "Id", "MembershipType", customers.MembershipTypeId);
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
