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
        public IActionResult Create(AddBlockVM model)
        {
            var block = new Block()
            {
                BlockName = model.BlockName,
                BlockAddress = model.BlockAddress,
                EnterDate = DateTime.Now
            };
            db.Block.Add(block);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult GetBlocks()
        {
            var model = db.Block.ToList();
            var model1 = (from b in db.Block
                          select new ViewModel
                          {
                              block = b
                          }).ToList();
            return PartialView(model1);
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
