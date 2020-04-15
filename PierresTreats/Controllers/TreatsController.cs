using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Pierre.Controllers
{
    [Authorize]
    public class TreatsController : Controller
    {
        private readonly PierresTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        
        public async Task<ActionResult> Index()
        {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
        return View(userTreats);
        }
  
        
        public ActionResult Create()
        {
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
        return View();
        }

       
       [HttpPost]
        public async Task<ActionResult> Create(Treat treat, int FlavorId)
        {
    
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        treat.User = currentUser;
        _db.Treats.Add(treat);
        if (FlavorId != 0)
        {
            _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
        }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

  
      public ActionResult Details(int id)
        {
            var thisTreat = _db.Treats
                .Include(treat => treat.Flavors)
                .ThenInclude(join => join.Flavor)
                .FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        
        }

  

        public async Task<ActionResult> Edit(int id)
        {
            if (FlavorId != 0)
            {
                _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
            }
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View(thisTreat);
        }


  
     

  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat myTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(myTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
  
    
        public async ActionResult AddFlavor(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View(thisTreat); 
        }

         [HttpPost]
        public ActionResult AddFlavor(Treat treat, int FlavorId)
        {
            if (FlavorId != 0)
            {
                _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

      
        public ActionResult Delete(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
            return View(thisTreat);
        }

        [HttpPost]
        public ActionResult DeleteFlavor(int joinId)
        {
        var joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
        _db.TreatFlavor.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
    }
}


