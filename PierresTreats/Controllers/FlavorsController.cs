using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Pierre.Controllers
    {
        [Authorize]
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

            [Authorize]
            public ActionResult Create()
            {
                return View();
            }
            [Authorize]
            [HttpPost]
            public ActionResult Create(Flavor flavor)
            {
                _db.Flavors.Add(flavor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            [Authorize]
            public ActionResult Details(int id)
            {
                Flavor myFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
                return View(myFlavor);
            }

            [Authorize]
            [HttpPost]
            public ActionResult Edit(int id)
            {
                Flavor myFlavor = _db.Flavors.FirstOrDefault(treat => treat.FlavorId == id);
                return View(myFlavor);
            }


            [Authorize]
            public ActionResult Delete(int id)
            {
                Flavor myFlavor = _db.Flavors.FirstOrDefault(treat => treat.FlavorId == id);
                return View(myFlavor);
            }

            [Authorize]
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