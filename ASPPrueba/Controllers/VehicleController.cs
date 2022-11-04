using ASPPrueba.Data;
using ASPPrueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPPrueba.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDBContext _db;

        public VehicleController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Vehicle> objVehicleList = _db.vehicles;
            return View(objVehicleList);
        }

        //create a row on a table
        public IActionResult Create()
        {
            return View();
        }
        //Pst 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle obj)
        {
            if (ModelState.IsValid)
            {
                _db.vehicles.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vehicleFromDb = _db.vehicles.Find(id);
            //var categoryFromDbFirst = _db.categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(c => c.Id == id);
            if (vehicleFromDb == null)
            {
                return NotFound();
            }
            return View(vehicleFromDb);
        }
        //Pst 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vehicle obj)
        {
            if (ModelState.IsValid)
            {
                _db.vehicles.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vehicleFromDb = _db.vehicles.Find(id);
            //var categoryFromDbFirst = _db.categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(c => c.Id == id);
            if (vehicleFromDb == null)
            {
                return NotFound();
            }
            return View(vehicleFromDb);
        }
        //Pst 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.vehicles.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.vehicles.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}