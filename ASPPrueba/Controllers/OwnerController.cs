using ASPPrueba.Data;
using ASPPrueba.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPPrueba.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ApplicationDBContext _db;

        public OwnerController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Owner> objOwnerList = _db.owners;
            return View(objOwnerList);
        }

        //create a row on a table
        public IActionResult Create()
        {
            return View();
        }
        //Pst 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Owner obj)
        {
            if (ModelState.IsValid)
            {
                _db.owners.Add(obj);
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
            var ownersFromDb = _db.owners.Find(id);
            //var categoryFromDbFirst = _db.categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(c => c.Id == id);
            if (ownersFromDb == null)
            {
                return NotFound();
            }
            return View(ownersFromDb);
        }
        //Pst 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Owner obj)
        {
            if (ModelState.IsValid)
            {
                _db.owners.Update(obj);
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
            var ownersFromDb = _db.owners.Find(id);
            //var categoryFromDbFirst = _db.categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.categories.SingleOrDefault(c => c.Id == id);
            if (ownersFromDb == null)
            {
                return NotFound();
            }
            return View(ownersFromDb);
        }
        //Pst 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.owners.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.owners.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}