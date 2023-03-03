﻿using DutchTreat.Services;
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
        public AppController(IMailService mailService )
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things happen to good developers");
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
    }

}
