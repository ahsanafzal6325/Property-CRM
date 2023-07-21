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
    public class FileController : Controller
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
        public IActionResult Create(AddFileVM model)
        {
            var file = new FileTab()
            {
                FileNo = model.FileNo,
                Marla = model.Marla,
                Area = model.Area,
                Amount = model.Amount,
                Site = 1,
                TenantId = 1
            };
            db.FileTab.Add(file);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult GetFiles()
        {
            //var model = db.Block.ToList();
            var model1 = (from f in db.FileTab
                          select new ViewModel
                          {
                              file = f
                          }).ToList();
            return PartialView(model1);
        }

        public IActionResult Filter(int? platID)
        {
            var Platter = (from f in db.Platter
                           select new { Text = f.PlatterName, Value = f.PlatterId }).ToList();
            ViewBag.Platter = new SelectList(Platter, "Value", "Text");
            if (platID == null)
            {
                var files = db.FileTab.ToList();
                return View(files);
            }
            else
            {
                var platter = db.Record.Where(x => x.PlatterId == platID).ToList();
                //var marla1 = platter.FirstOrDefault(x => x.PlatterId == platID)?.Marla ?? 0;
                var sqrFeet3 = 816;
                var sqrFeet5 = 1361;
                var sqrFeet7 = 1906;
                //var Marla = platter.Where(x => x.Marla == 3).ToList();
                var quantity1 = platter.FirstOrDefault(x => x.Marla == 3)?.Quantity ?? 0;
                var quantity2 = platter.FirstOrDefault(x => x.Marla == 5)?.Quantity ?? 0;
                var quantity3 = platter.FirstOrDefault(x => x.Marla == 7)?.Quantity ?? 0;
                var files = db.FileTab.Where(x => x.Area == sqrFeet3).Take(quantity1)
                    .Concat(db.FileTab.Where(x => x.Area == sqrFeet5).Take(quantity2))
                    .Concat(db.FileTab.Where(x => x.Area == sqrFeet7).Take(quantity3)).ToList();
                    
                return View(files);

            }
        }

        //public IActionResult Platter(int? PlatId)
        //{
        //    var Platter = (from f in db.Platter
        //                       select new { Text = f.PlatterName, Value = f.PlatterId }).ToList();
        //    ViewBag.Platter = new SelectList(Platter, "Value", "Text");
        //    return View();
        //}


        //public IActionResult Filter()
        //{
        //    //var record = db.Record.Where(x => x.PlatterID == platID).FirstOrDefault();

        //    var records = (from d in db.FileTab.Where()
        //                   select new RecordVM
        //                   {
        //                       rec = d
        //                   }).ToList();
        //    return View(records);
        //}
    }
}
