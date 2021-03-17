using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleScheduler.Models;

namespace TempleScheduler.Controllers
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

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]//after the user clicks the button
        public IActionResult SignUp(Group group)
        {
            return View("Form",group);
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]//after the user clicks the button
        public IActionResult Form( Group group)
        {
            //Debug.WriteLine("GroupName: " + group.GroupName);
            return View("Form", group);
        }

        public IActionResult Appointment()
        {

            return View();
        }


        public IActionResult Privacy()
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
