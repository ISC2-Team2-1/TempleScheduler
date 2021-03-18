using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TempleScheduler.Models;
using TempleScheduler.Models.ViewModels;

namespace TempleScheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly GroupDbContext _db;

        public HomeController(ILogger<HomeController> logger, GroupDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            if (ModelState.IsValid)
            {
                List<string> time_list = new List<string>()
                {
                    "8:00am - 9:00am",
                    "9:00am - 10:00am",
                    "10:00am - 11:00am",
                    "11:00am - 12:00pm",
                    "12:00pm - 1:00pm",
                    "1:00pm - 2:00pm",
                    "2:00pm - 3:00pm",
                    "3:00pm - 4:00pm",
                    "4:00pm - 5:00pm",
                    "5:00pm - 6:00pm",
                    "6:00pm - 7:00pm",
                    "7:00pm - 8:00pm",
                    "8:00pm - 9:00pm",
                };

                ViewBag.TimesList = time_list;
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SignUp(AvailableTime timeslot)
        {
            if (ModelState.IsValid)
            {


                ViewBag.Timeslots = timeslot;
                ViewBag.time = timeslot.Timeslots;
                return View("Form");
            }

            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]//after the user clicks the button
        public IActionResult Form( Group group)
        {
            if (ModelState.IsValid)
            {
                _db.Groups.Add(group);
                _db.SaveChanges();
                return View("Index");
            }

            else
            {
                return View();
            }
            
        }

        public IActionResult Appointment()
        {
            List<Group> groups = new List<Group>();
            groups = _db.Groups.ToList();
            return View(groups);
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
