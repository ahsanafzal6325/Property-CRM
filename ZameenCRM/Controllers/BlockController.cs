using DATA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZameenCRM.Models;

namespace ZameenCRM.Controllers
{
    public class BlockController : Controller
    {
        FinalDBContext db = new FinalDBContext();
        public IActionResult Index()
        {
            var model = db.Block.ToList();
            return View(model);
        }
        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView();
        }
        //[HttpPost]
        //public IActionResult Create(AddBlockVM model)
        //{
        //    var proj = new Block()
        //    {
        //        BlockName = model
        //    };
        //    db.Project.Add(proj);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
