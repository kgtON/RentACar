using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RadexRent.Models;

namespace RadexRent.Controllers
{
    public class CarReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarReservations
        public ActionResult Index()
        {
            return View(db.CarReservation.ToList());
        }

        // GET: CarReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarReservation carReservation = db.CarReservation.Find(id);
            if (carReservation == null)
            {
                return HttpNotFound();
            }
            return View(carReservation);
        }

        // GET: CarReservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,StartPlace,EndPlace")] CarReservation carReservation)
        {
            if (ModelState.IsValid)
            {
                db.CarReservation.Add(carReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carReservation);
        }

        // GET: CarReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarReservation carReservation = db.CarReservation.Find(id);
            if (carReservation == null)
            {
                return HttpNotFound();
            }
            return View(carReservation);
        }

        // POST: CarReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,StartPlace,EndPlace")] CarReservation carReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carReservation);
        }

        // GET: CarReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarReservation carReservation = db.CarReservation.Find(id);
            if (carReservation == null)
            {
                return HttpNotFound();
            }
            return View(carReservation);
        }

        // POST: CarReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarReservation carReservation = db.CarReservation.Find(id);
            db.CarReservation.Remove(carReservation);
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
