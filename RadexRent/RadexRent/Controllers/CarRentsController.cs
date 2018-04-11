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

        public CarRentsController(
            ICarRentsRepository carRentsRepository
            )
        {
            _carRentsRepository = carRentsRepository;
        }

        // GET: CarRents
        public ActionResult Index()
        {
            return View(_carRentsRepository.GetWhere(i => i.Id > 0));
        }

        // GET: CarRents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRent carRent = _carRentsRepository.GetWhere(i => i.Id.Equals(id.Value)).FirstOrDefault();
            if (carRent == null)
            {
                return HttpNotFound();
            }
            return View(carRent);
        }

        // GET: CarRents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarRents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarRent carRent)
        {
            if (ModelState.IsValid)
            {
                _carRentsRepository.Create(carRent);
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
            CarRent carRent = _carRentsRepository.GetWhere(i => i.Id==id.Value).FirstOrDefault();
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
            CarRent carRent = _carRentsRepository.GetWhere(i => i.Id.Equals(id.Value)).FirstOrDefault();
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
