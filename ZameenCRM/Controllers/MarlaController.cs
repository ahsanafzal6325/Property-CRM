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
    public class MarlaController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Create()
        {
            var plan = (from s in db.Plans
                        select new { Text = s.PlanName, Value = s.SiteId }).ToList();
            ViewBag.Plan = new SelectList(plan, "Value", "Text");
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(AddMarlaVM model)
        {
            var mar = new Marla()
            {
                MarlName = model.MarlaName,
                PlanId = model.PlanId,
                MarlaPrice = model.MarlaPrice,
                SiteId = 1,
                EnterDate = DateTime.Now,
                EditDate = DateTime.Now
            };
            db.Marla.Add(mar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult GetMarla()
        {
            var model = db.Marla.ToList();
            var ProjectDetail = (from m in db.Marla
                                 join p in db.Plans on m.PlanId equals p.PlanId
                                 select new ViewModel
                                 {
                                     mar = m,
                                     plan = p
                                 }).ToList();
            return PartialView(ProjectDetail);
        }
    }
}
