using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _Repository;
        public AppController(IMailService mailService, IDutchRepository Repository)
        {
            _mailService = mailService;
            _Repository = Repository;
        }

        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things happen to good developers");
            //var results = _Repository.Products.ToList();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {

            //throw new InvalidProgramException("Bad things happen to good developers");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Send email
                _mailService.SendMessage("isaacesquer@hotmail.com", model.Subject, $"From: { model.Name } { model.Name}, { model.Message }");
                ViewBag.UserMessage = " Mail Sent ";
                ModelState.Clear();

            }


            return View();

        }

        [HttpGet("about")]
        public IActionResult About()
        {


            return View();
        }

        public IActionResult Shop()
        {
            //var result = _Repository.GetAllProducts();
            var result = _Repository.GetAllProducts();
            return View(result);
 
        }
    }


}
