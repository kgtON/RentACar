using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RadexRent.Models;
using RadexRent.Repository;
using RadexRent.Repository.Interfacecs;

namespace RadexRent.Controllers
{
    public class CarReservationsController : Controller
    {
        private readonly ICarReservationRepository _carReservationRepository;
        private readonly ICarRentsRepository _carRentRepository;

        public CarReservationsController(
            ICarReservationRepository carReservationRepository,
            ICarRentsRepository carRentRepository
            )
        {
            _carReservationRepository = carReservationRepository;
            _carRentRepository = carRentRepository;
        }

        // GET: CarReservations
        public ActionResult Index()
        {
           
            return View(_carReservationRepository.GetWhere(i => i.Id > 0));
        }

        // GET: CarReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarReservation carReservation = _carReservationRepository.GetWhere(i => i.Id.Equals(id.Value)).FirstOrDefault();
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
        public ActionResult Create(CarReservation carReservation)
        {
            if (ModelState.IsValid)
            {
                _carReservationRepository.Create(carReservation);
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
            CarReservation carReservation = _carReservationRepository.GetWhere(i => i.Id == id.Value).FirstOrDefault();
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
                _carReservationRepository.Edit(carReservation);
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
            CarReservation carReservation = _carReservationRepository.GetWhere(i => i.Id.Equals(id.Value)).FirstOrDefault();
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
            CarReservation carReservation = _carReservationRepository.GetWhere(i => i.Id == id).FirstOrDefault();
            _carReservationRepository.Delete(carReservation);
            return RedirectToAction("Index");
        }
    }
}
