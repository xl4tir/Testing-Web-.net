using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppTesting.Models;
using WebAppTesting.Domain.Entity;
using WebAppTesting.DAL.Interfaces;

namespace WebAppTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITesting _testing;


        public HomeController(ITesting itesting)
        {
            _testing = itesting;
        }


        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
