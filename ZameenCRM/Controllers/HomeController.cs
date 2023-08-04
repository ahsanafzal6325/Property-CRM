using DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZameenCRM.Models;

namespace ZameenCRM.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<UserRights> userRights = HttpContext.Session.GetObject<List<UserRights>>("UserRights");

            Users user = HttpContext.Session.GetObject<Users>("Users");
            if (user == null)
            {
                return RedirectToAction("Login", "Controller");
            }
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
        public IActionResult GetUserDashboard()
        {

            DashboardVM Dashb = new DashboardVM();

            var files = db.FileTab.Count();
            var Platter = db.Platter.Count();
            Dashb.TotalFiles = files;
            Dashb.TotalPlatters = Platter;
           
            return PartialView("_UserDashboard", Dashb);
        }
    }
}
