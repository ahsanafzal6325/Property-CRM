using DATA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZameenCRM.Models;

namespace ZameenCRM.Controllers
{
    public class RecordController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();

        public IActionResult Index()
        {
            var model = db.Platter.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            var Project = (from f in db.Project
                               select new { Text = f.ProjectName, Value = f.ProjectID }).ToList();
            ViewBag.Project = new SelectList(Project, "Value", "Text");
            var Area = (from f in db.Area
                           select new { Text = f.AreaName, Value = f.AreaId }).ToList();
            ViewBag.Area = new SelectList(Area, "Value", "Text");
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromBody] List<AddPlatterVM> plattersData)
        {
            return View();
        }
        public IActionResult GetRecords(int Id)
        {
           
            return View();
        }
        //public IActionResult CreateEx()
        //{
        //    var model = new List<AddPlatterVM>
        //{
        //    new AddPlatterVM(),
        //    new AddPlatterVM()
        //};
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult CreateEx([FromBody] List<ExPlatterVM> plattersData)
        //{
        //    return Json(plattersData);
        //}
    }
}
