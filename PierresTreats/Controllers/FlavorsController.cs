using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                return View(_db.Flavors.ToList());
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
                Flavor myFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
                return View(myFlavor);
            }

            [HttpPost]
            public ActionResult Edit(int id)
            {
                Flavor myFlavor = _db.Flavors.FirstOrDefault(treat => treat.FlavorId == id);
                return View(myFlavor);
            }

          
            public ActionResult Delete(int id)
            {
                Flavor myFlavor = _db.Flavors.FirstOrDefault(treat => treat.FlavorId == id);
                return View(myFlavor);
            }

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                Flavor myFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
                _db.Flavors.Remove(myFlavor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }