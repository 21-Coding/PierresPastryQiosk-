using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Pierre.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Pierre.Controllers
{
    [Authorize]
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

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            Treat myTreat = _db.Treats
            .Include(treat => treat.Flavors)
            .ThenInclude(join => join.Flavor)
            .FirstOrDefault(treat => treat.TreatId == id);
            return View(myTreat);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(myTreat);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public ActionResult Delete(int id)
        {
            Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(myTreat);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(myTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult AddFlavor(int id)
        {
        Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
        return View(thisTreat);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int FlavorId)
        {
        if (FlavorId != 0)
        {
            _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
        }
        _db.SaveChanges();
        return RedirectToAction("Details", "Treats", new { id = treat.TreatId });
        }
            
    }
}


