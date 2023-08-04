using DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZameenCRM.Models;

namespace ZameenCRM.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Block = (from f in db.Block
                           select new { Text = f.BlockName, Value = f.BlockId }).ToList();
            ViewBag.Block = new SelectList(Block, "Value", "Text");
            var plan = (from f in db.Plans
                         select new { Text = f.PlanName, Value = f.PlanId }).ToList();
            ViewBag.Plans = new SelectList(plan, "Value", "Text");
            var Type = (from f in db.TypeTab
                         select new { Text = f.TypeName, Value = f.TypeId }).ToList();
            ViewBag.Type = new SelectList(Type, "Value", "Text");
            var Marla = (from f in db.Marla
                        select new { Text = f.MarlName, Value = f.MarlaID }).ToList();
            ViewBag.Marla = new SelectList(Marla, "Value", "Text");
            var fileNo = db.FileTab.Max(x=>x.FileNo);
            fileNo = fileNo + 1;
            ViewBag.fileNo = fileNo;
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] AddFileVM model)
        {
            var file = new FileTab()
            {
                FileNo = model.FileNo,
                Marla = model.Marla,
                Area = model.Area,
                ProjectId = model.ProjectId,
                BlockId = model.BlockId,
                EnterDate = DateTime.Now,
                Amount = model.Amount,
                Site = 1,
                TenantId = 1
            };
            db.FileTab.Add(file);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetMarlasByPlanId(int planId)
        {
            var marlas = db.Marla.Where(m => m.PlanId == planId).ToList();
            var marlaSelectList = marlas.OrderBy(m => m.MarlName).Select(m => new SelectListItem { Value = m.MarlaID.ToString(), Text = m.MarlName.ToString() }).ToList();
            return Json(marlaSelectList);
        }
        public IActionResult GetPriceByMarla(int marlaId)
        {
            var marla = db.Marla.Find(marlaId);
            if (marla != null)
            {
                return Json(marla.MarlaPrice);
            }
            return Json(0);
        }
        public PartialViewResult GetFiles()
        {
            //var model = db.Block.ToList();
            var model1 = (from f in db.FileTab
                          join p in db.Project on f.ProjectId equals p.ProjectID
                          join b in db.Block on f.BlockId equals b.BlockId
                          join t in db.TypeTab on f.Type equals t.TypeId
                          select new ViewModel
                          {
                              file = f,
                              block = b,
                              pro = p,
                              type = t
                          }).ToList();

            return PartialView(model1);
        }

        public IActionResult Filter(int? platID,int? BlockId,int? PojectId)
        {
            var allPlatters = db.Record.ToList();
            //var groupedPlatters = allPlatters.GroupBy(x => x.PlatterId).Select(x => x.First()).ToList();
            //ViewBag.Platter =  groupedPlatters;
            var Platter = (from f in db.Platter
                           select new { Text = f.Description, Value = f.PlatterNo }).ToList();
            ViewBag.Platter = new SelectList(Platter, "Value", "Text");
            if (platID == null)
            {
                var file = (from f in db.FileTab
                            join p in db.Project on f.ProjectId equals p.ProjectID
                            join b in db.Block on f.BlockId equals b.BlockId
                            select new ViewModel
                            {
                                file = f,
                                pro = p,
                                block = b
                            }).ToList();
                return View(file);
            }
            else
            {
                var platter = db.Record.Where(x => x.PlatterId == platID).ToList();
                List<ViewModel> listFiles = new List<ViewModel>();
                var marla1 = db.Record.Where(x => x.PlatterId == platID).ToList();
                foreach (var item in marla1)
                {

                    var quantity = platter.FirstOrDefault(x => x.Area == item.Area)?.Quantity ?? 0;
                    //var files = db.FileTab.Where(x => x.Area == item.Area && x.ProjectId == item.ProjectId).Take(quantity).ToList();

                    var file = (from f in db.FileTab.Where(x => x.Area == item.Area && x.ProjectId == item.ProjectId)
                                join p in db.Project on f.ProjectId equals p.ProjectID
                                join b in db.Block on f.BlockId equals b.BlockId
                                select new ViewModel()
                                {
                                    file = f,
                                    pro = p,
                                    block = b
                                }).Take(quantity).ToList();
                    listFiles.AddRange(file);
                }
                return View(listFiles);
            }
        }
        

        public IActionResult AllPlatter()
        {
            var platter = db.Platter.ToList();
            return View(platter);
        }
        public IActionResult GetListPlatter(int platterNo)
        {
            var platter = db.Record.Where(x => x.PlatterId == platterNo).ToList();
            return View(platter);
        }


        
        
        
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
