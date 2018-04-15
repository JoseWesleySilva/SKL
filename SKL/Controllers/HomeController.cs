using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SKL.Models;

namespace SKL.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(SkldbMainContext context)
        { }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
