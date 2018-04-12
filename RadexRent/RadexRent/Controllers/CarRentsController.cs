using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RadexRent.Models;
using RadexRent.Repository.Interfacecs;

namespace RadexRent.Controllers
{
    public class CarRentsController : Controller
    {
        private readonly ICarRentsRepository _carRentsRepository;
        private readonly IApplicationUserRepository _appUserRepository;

        public CarRentsController(
            ICarRentsRepository carRentsRepository,
            IApplicationUserRepository appUserRepository
            )
        {
            _carRentsRepository = carRentsRepository;
            _appUserRepository = appUserRepository;
        }

        // GET: CarRents
        public ActionResult Index()
        {
            var carRents = _carRentsRepository.GetWhere(i => i.ApplicationUserId != Guid.Empty).ToList();
            return View(carRents);
        }

        // GET: CarRents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRent carRent = _carRentsRepository.GetWhere(i => i.Id == id.Value).FirstOrDefault();
            if (carRent == null)
            {
                return HttpNotFound();
            }
            return View(carRent);
        }

        // GET: CarRents/Create
        public ActionResult Create()
        {
            CarRentViewModel carRentVM = new CarRentViewModel();

            var users = _appUserRepository.GetWhere(i => i.Id != string.Empty);
            var listElements = new List<SelectListItem>();

            foreach (var user in users)
            {
                listElements.Add(new SelectListItem
                {
                    Value = user.Id.ToString(),
                    Text = user.UserName
                });
            };
            carRentVM.ListUsers = new SelectList(listElements, "Value", "Text");
            //return this;
            return View(carRentVM);
        }

        // POST: CarRents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarRentViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.carRent.ApplicationUserId = model.UserID;
                _carRentsRepository.Create(model.carRent);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: CarRents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRent carRent = _carRentsRepository.GetWhere(i => i.Id == id.Value).FirstOrDefault();
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
        public ActionResult Edit(CarRent carRent)
        {
            if (ModelState.IsValid)
            {
                _carRentsRepository.Edit(carRent);
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
            CarRent carRent = _carRentsRepository.GetWhere(i => i.Id == id.Value).FirstOrDefault();
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
            CarRent carRent = _carRentsRepository.GetWhere(i => i.Id == id).FirstOrDefault();
            _carRentsRepository.Delete(carRent);
            return RedirectToAction("Index");
        }

    }
}
