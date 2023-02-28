using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things happen to good developers");
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            //throw new InvalidProgramException("Bad things happen to good developers");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";

            return View();
        }
    }

}
