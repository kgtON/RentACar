using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RadexRent.Models;
using RadexRent.Repository.Interfaces;

namespace RadexRent.Controllers
{
    public class CarModelsController : Controller
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelsController(
            ICarModelRepository carModelRepository
            )
        {
            _carModelRepository = carModelRepository;
        }

        // GET: CarModels
        public ActionResult Index()
        {
            return View(_carModelRepository.GetWhere(i => i.Id > 0));
        }

        // GET: CarModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = _carModelRepository.GetWhere(i => i.Id.Equals(id.Value)).FirstOrDefault();
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _carModelRepository.Create(carModel);
                return RedirectToAction("Index");
            }

            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = _carModelRepository.GetWhere(i => i.Id == id.Value).FirstOrDefault();
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _carModelRepository.Edit(carModel);
                return RedirectToAction("Index");
            }
            return View(carModel);
        }

        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = _carModelRepository.GetWhere(i => i.Id.Equals(id.Value)).FirstOrDefault();
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel carModel = _carModelRepository.GetWhere(i => i.Id == id).FirstOrDefault();
            _carModelRepository.Delete(carModel);
            return RedirectToAction("Index");
        }

    }
}
