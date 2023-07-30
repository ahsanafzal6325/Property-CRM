using DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZameenCRM.Models;

namespace ZameenCRM.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
       public PartialViewResult Create()
        {
            var Site = (from s in db.Site
                        select new { Text = s.SiteName, Value = s.SiteId }).ToList();
            ViewBag.Site = new SelectList(Site, "Value", "Text");
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(AddProjectVM model)
        {
            var proj = new Project()
            {
                ProjectName = model.ProjectName,
                SiteId = 1,
                EnterDate = DateTime.Now,
                EditDate = DateTime.Now
            };
            db.Project.Add(proj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult GetProjects()
        {
            var model = db.Project.ToList();
            var ProjectDetail = (from p in db.Project
                                 join s in db.Site on p.SiteId equals s.SiteId
                                 select new ViewModel
                                 {
                                     pro = p,
                                     site = s
                                 }).ToList();
            return PartialView(ProjectDetail);
        }
      
    }
}
