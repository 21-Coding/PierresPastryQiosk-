using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameWorkCore;
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


        }
    }