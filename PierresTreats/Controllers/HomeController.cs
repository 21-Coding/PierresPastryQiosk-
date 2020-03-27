using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Pierre.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}