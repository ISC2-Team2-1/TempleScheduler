using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
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
            List<AvailableTime> times = new List<AvailableTime>();
            times = _db.Times.ToList();
            ViewBag.TimesList = times;
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(AvailableTime timeslot)
        {
            if (ModelState.IsValid)
            {

                ViewBag.Timeslots = timeslot;
                _db.Times.Add(timeslot);
                _db.SaveChanges();

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
                group.Timeslots = _db.Times.Find(group.TimeID);
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
