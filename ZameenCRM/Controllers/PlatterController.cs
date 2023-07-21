using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZameenCRM.Controllers
{
    public class PlatterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult Create()
        {
            return PartialView();
        }
    }
}
