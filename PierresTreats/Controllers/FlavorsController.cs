using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Pierre.Controllers
    {

         public class FlavorsController : Controller
        {
            private readonly PierresTreatsContext _db;

            public FlavorsController(PierresTreatsContext db)
            {
                _db = db;
            }

            public ActionResult Index()
             {
               List<Flavor> model = _db.Flavors.ToList();
               return View(model);
             }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(Flavor flavor)
            {
                _db.Flavors.Add(flavor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            public ActionResult Details(int id)
            {
                var myFlavor = _db.Flavors
                    .Include(flavor => flavor.Treats)
                    .ThenInclude(join => join.Treat)
                    .FirstOrDefault(flavor => flavor.FlavorId == id);
                return View(myFlavor);
            }
            public ActionResult Edit(int id)
            {
                var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
                return View(thisFlavor);
            }

            [HttpPost]
            public ActionResult Edit(Flavor flavor)
            {
                _db.Entry(flavor).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            public ActionResult Delete(int id)
            {
                var myFlavor = _db.Flavors.FirstOrDefault(treat => treat.FlavorId == id);
                return View(myFlavor);
            }


            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                var myFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
                _db.Flavors.Remove(myFlavor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
