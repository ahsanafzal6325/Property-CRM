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
    public class PlatterController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var Project = (from f in db.Project
                           select new { Text = f.ProjectName, Value = f.ProjectID }).ToList();
            ViewBag.Project = new SelectList(Project, "Value", "Text");
            var PlatterId = db.Platter.Max(p => p.PlatterId);
            PlatterId = PlatterId + 1;
            ViewBag.PlatterId = PlatterId;
            return View();
        }
        public PartialViewResult GetAll()
        {
            var listPlat = HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList");
            return PartialView("_PlatterRows", listPlat);
        }
        [HttpPost]
        public IActionResult Create(AddPlatterVM model)
        {
            var listPlat = HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList");
            var Project = (from f in db.Project
                           select new { Text = f.ProjectName, Value = f.ProjectID }).ToList();
            ViewBag.Project = new SelectList(Project, "Value", "Text");
            if (listPlat == null)
            {
                listPlat = new List<AddPlatterVM>();
            }
            var ProjectName = db.Project.Find(model.ProjectId);
            model.ProjectName = ProjectName.ProjectName;
            var plat = new AddPlatterVM()
            {
                Recno = listPlat.Count == 0 ? 1 : listPlat.Max(p => p.Recno) + 1,
                PlatterName = model.PlatterName,
                RebutAmount = model.RebutAmount,
                Area = model.Area,
                Type = model.Type,
                Quantity = model.Quantity,
                ProjectName = model.ProjectName
            };
            ViewBag.PlatterName = model.PlatterName;
            ViewBag.ProjectName = ProjectName.ProjectName;
            listPlat.Add(plat);

            HttpContext.Session.SetObject("PlatterList", listPlat);

            return View();
        }
        public IActionResult DeleteRow(int id)
        {
            var listPlat = HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList");
            var find = listPlat.Find(x => x.Recno == id);
            listPlat.Remove(find);
            HttpContext.Session.SetObject("PlatterList", listPlat);
            return RedirectToAction("Create");
        }
        public IActionResult SavePlat()
        {
            var listPlat = HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList");
          
            foreach (var item in listPlat)
            {
                item.PlatterId = ViewBag.PlatterId;
            }
            foreach (var item in listPlat)
            {
                var plat = new Platter()
                {
                    PlatterName = item.PlatterName,
                    Area = item.Area,
                    Quantity = item.Quantity,
                    PlatterId = item.PlatterId,
                    Type = item.Type,
                    ProjectId = item.ProjectId,
                };
                db.Platter.Add(plat);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult AnotherAction()
        {
            var listPlat = HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList");

            foreach (var item in listPlat)
            {

            }
            // Use the listPlat as needed in this action
            // ...

            return View();
        }
    }
}
