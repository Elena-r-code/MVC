﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaApp;
using PizzaApp.Models;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("AboutUs")]
        public IActionResult About()
        {
            StaticDb.Message = "About action changed the message!";
            return View();
        }
        [Route("ContactUs")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ReturnAnotherView()
        {
            return View("NewView"); //Home folder -> NewView.cshtml
        }

        [Route("SeeUsers")]

        public IActionResult SeeUsers()
        {
            List<UserDetailsViewModel> userDetailsViewModels = StaticDb.Users
                .Select(x => x.UserToUserDetailsViewModel(x)).ToList();
            ViewBag.Users = userDetailsViewModels;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//localhost:344/ContactUs
//localhost:344/AboutUs