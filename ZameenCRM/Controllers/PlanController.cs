using DATA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZameenCRM.Models;

namespace ZameenCRM.Controllers
{
    public class PlanController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(AddPlanVM model)
        {
            var proj = new Plans()
            {
                PlanName = model.PlanName,
                SiteId = 1,
                EnterDate = DateTime.Now,
                EditDate = DateTime.Now
            };
            db.Plans.Add(proj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult GetPlans()
        {
            var model = db.Plans.ToList();
            var ProjectDetail = (from p in db.Plans
                                 select new ViewModel
                                 {
                                     plan = p,
                                 }).ToList();
            return PartialView(ProjectDetail);
        }
    }
}
