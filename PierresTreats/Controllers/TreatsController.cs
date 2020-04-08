using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pierre.Controllers
{
    public class TreatsController : Controller
    {
        private readonly PierresTreatsContext _db;

        public TreatsController(PierresTreatsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Treats.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Treat myTreat = _db.Treats
            .Include(treat => treat.Flavors)
            .ThenInclude(join => join.Flavor)
            .FirstOrDefault(treat => treat.TreatId == id);
            return View(myTreat);
        }

        public ActionResult Edit(int id)
        {
            Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(myTreat);
        }

        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddFlavor(int id)
        {
            Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View(myTreat);
        }

        // [HttpPost]
        // public ActionResult AddFlavor(Treat treat, int FlavorId)
        // {
        //
        // }

        // public ActionResult Delete()
        // {
        //     Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        //     return View(myTreat);
        // }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(myTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
