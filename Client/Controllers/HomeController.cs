﻿using Client.Models;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RequestRepository requestRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //jika sudah login
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.userId = HttpContext.Session.GetString("UserId");
                ViewBag.firstName = HttpContext.Session.GetString("FirstName");
                ViewBag.salary = HttpContext.Session.GetInt32("Salary");
                ViewBag.manager = HttpContext.Session.GetString("Manager");
                ViewBag.email = HttpContext.Session.GetString("Email");
                return View();
            }
            //jika belom login
            return RedirectToAction("Index", "Login");
        }

        public IActionResult Status()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
