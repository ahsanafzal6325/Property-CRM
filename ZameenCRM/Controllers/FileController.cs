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

        //public IActionResult Filter(int? platID)
        //{
        //    //var Platter = (from f in db.Platter
        //    //               select new { Text = f.PlatterName, Value = f.PlatterId }).ToList();
        //    //ViewBag.Platter = new SelectList(Platter, "Value", "Text");
        //    //if (platID == null)
        //    //{
        //    //    var file = (from f in db.FileTab
        //    //                join p in db.Project on f.ProjectId equals p.ProjectID
        //    //                join b in db.Block on f.BlockId equals b.BlockId
        //    //                select new ViewModel
        //    //                {
        //    //                    file = f,
        //    //                    pro = p,
        //    //                    block = b
        //    //                }).ToList();
        //    //    return View(file);
        //    //}
        //    //else
        //    //{
        //    //    var platter = db.Record.Where(x => x.PlatterId == platID).ToList();
        //    //    List<ViewModel> listFiles = new List<ViewModel>();
        //    //    var marla1 = db.Record.Where(x => x.PlatterId == platID).ToList();
        //    //    foreach (var item in marla1)
        //    //    {

        //    //        var quantity = platter.FirstOrDefault(x => x.Marla == item.Marla)?.Quantity ?? 0;
        //    //        //var files = db.FileTab.Where(x => x.Area == item.Area && x.ProjectId == item.ProjectId).Take(quantity).ToList();

        //    //        var file = (from f in db.FileTab.Where(x => x.Area == item.Area && x.ProjectId == item.ProjectId)
        //    //                    join p in db.Project on f.ProjectId equals p.ProjectID
        //    //                    join b in db.Block on f.BlockId equals b.BlockId
        //    //                    select new ViewModel()
        //    //                    {
        //    //                        file = f,
        //    //                        pro = p,
        //    //                        block = b
        //    //                    }).Take(quantity).ToList();
        //    //        listFiles.AddRange(file);
        //    //    }
        //    //    return View(listFiles);
        //    //}
        //}
        ////public IActionResult Platter(int? PlatId)
        ////{
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
