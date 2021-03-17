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
            return View();
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
            //Debug.WriteLine("GroupName: " + group.GroupName);
            //    return View("Form", group);
            //    _db.Groups.Add(group);
            //    _db.SaveChanges();
            //    //Add what is returned to the database, add he group to the database
            
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
