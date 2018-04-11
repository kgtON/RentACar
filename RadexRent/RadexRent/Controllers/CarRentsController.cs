using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RadexRent.Models;
using RadexRent.Repository.Interfacecs;
using RadexRent.Repository.Interfaces;

namespace RadexRent.Controllers
{
    public class CarRentsController : Controller
    {
        private readonly ICarRentsRepository _carRentsRepository;

        public CarRentsController(
            ICarRentsRepository carRentsRepository
            )
        {
            _carRentsRepository = carRentsRepository;
        }

        // GET: CarRents
        public ActionResult Index()
        {
            return View(_carRentsRepository.GetWhere(i => !i.ApplicationUserId.Equals());
        }

        // GET: CarRents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRent carRent = db.CarRents.Find(id);
            if (carRent == null)
            {
                return HttpNotFound();
            }
            return View(carRent);
        }

        // GET: CarRents/Create
        public ActionResult Create()
        {
            CarViewModel carViewModel = new CarViewModel();
            var userList = db.Users.Where(i => i.Id.Length > 0).ToList().FirstOrDefault();
            return View();
        }

        // POST: CarRents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserId,StartDateTime,EndDateTime,StartLocation,EndLocation,Distance,FuelWasted,TotalCost")] CarRent carRent)
        {
            if (ModelState.IsValid)
            {
                db.CarRents.Add(carRent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carRent);
        }

        // GET: CarRents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRent carRent = db.CarRents.Find(id);
            if (carRent == null)
            {
                return HttpNotFound();
            }
            return View(carRent);
        }

        // POST: CarRents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserId,StartDateTime,EndDateTime,StartLocation,EndLocation,Distance,FuelWasted,TotalCost")] CarRent carRent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carRent);
        }

        // GET: CarRents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRent carRent = db.CarRents.Find(id);
            if (carRent == null)
            {
                return HttpNotFound();
            }
            return View(carRent);
        }

        // POST: CarRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarRent carRent = db.CarRents.Find(id);
            db.CarRents.Remove(carRent);
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
