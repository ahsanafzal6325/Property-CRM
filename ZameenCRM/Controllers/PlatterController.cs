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

    public class PlatterController : Controller
    {
        FinalDBCotext db = new FinalDBCotext();
        public static string platName;
        public static int? platAmount;
        public static int? platId;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var Project = (from f in db.Project
                           select new { Text = f.ProjectName, Value = f.ProjectID }).ToList();
            ViewBag.Project = new SelectList(Project, "Value", "Text");
            var Block = (from f in db.Block
                         select new { Text = f.BlockName, Value = f.BlockId }).ToList();
            ViewBag.Block = new SelectList(Block, "Value", "Text");
            var Type = (from f in db.TypeTab
                        select new { Text = f.TypeName, Value = f.TypeId }).ToList();
            ViewBag.Type = new SelectList(Type, "Value", "Text");
            var PlatterId = db.Record.Max(p => p.PlatterId);
            if (PlatterId == null)
            {
                platId = 1;
            }
            else
            {
                PlatterId = PlatterId + 1;
                platId = PlatterId;
            }
            ViewBag.PlatterName = platName;
            ViewBag.PlatterAmount = platAmount;
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(AddPlatterVM model)
        {
            var listPlat = HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList");
            var Project = (from f in db.Project
                           select new { Text = f.ProjectName, Value = f.ProjectID }).ToList();
            ViewBag.Project = new SelectList(Project, "Value", "Text");
            var Block = (from f in db.Block
                         select new { Text = f.BlockName, Value = f.BlockId }).ToList();
            ViewBag.Block = new SelectList(Block, "Value", "Text");
            var Type = (from f in db.TypeTab
                        select new { Text = f.TypeName, Value = f.TypeId }).ToList();
            ViewBag.Type = new SelectList(Type, "Value", "Text");
            if (listPlat == null)
            {
                listPlat = new List<AddPlatterVM>();
            }
            var ProjectName = db.Project.Find(model.ProjectId);
            model.ProjectName = ProjectName.ProjectName;
            var BlockName = db.Block.Find(model.BlockId);
            model.BlockName = BlockName.BlockName;
            var TypeName = db.TypeTab.Find(model.TypeId);
            model.TypeName = TypeName.TypeName;
            var plat = new AddPlatterVM()
            {
                Recno = listPlat.Count == 0 ? 1 : listPlat.Max(p => p.Recno) + 1,
                PlatterName = model.PlatterName,
                RebutAmount = model.RebutAmount,
                Area = model.Area,
                Marla = model.Marla,
                TypeId = model.TypeId,
                BlockId = model.BlockId,
                Quantity = model.Quantity,
                ProjectId = model.ProjectId,
                EnterDate = model.EnterDate,
                ProjectName = model.ProjectName,
                BlockName = model.BlockName,
                TypeName = model.TypeName
            };
            ViewBag.PlatterName = model.PlatterName;
            ViewBag.ProjectName = ProjectName.ProjectName;
            ViewBag.PlatterAmount = model.RebutAmount;
            platName = model.PlatterName;
            platAmount = model.RebutAmount;
            listPlat.Add(plat);
            HttpContext.Session.SetObject("PlatterList", listPlat);
            return View();
        }
        public PartialViewResult GetAll()
        {
            var listPlat = HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList");
            return PartialView("_PlatterRows", listPlat);
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
            int? ActualSize = 0;
            int? NetAmount = 0;
            string Desc = "";
            int? RebutAmount = 0;
            int? ActualAmount;
            foreach (var item in listPlat)
            {
                item.PlatterId = platId;
                ActualSize = item.Quantity * item.Area + ActualSize;
                NetAmount = item.Quantity * item.RebutAmount + NetAmount;
                Desc = item.PlatterName;
                RebutAmount = item.RebutAmount;
            }
            ActualAmount = NetAmount + RebutAmount;
            foreach (var item in listPlat)
            {
                var plat = new Record()
                {
                    PlatterName = item.PlatterName,
                    Area = item.Area,
                    Quantity = item.Quantity,
                    Marla = item.Marla,
                    PlatterId = item.PlatterId,
                    RebutAmount = item.RebutAmount,
                    Type = item.TypeId,
                    EnterDate = item.EnterDate,
                    ProjectId = item.ProjectId,
                    BlockId = item.BlockId
                };
                db.Record.Add(plat);
                db.SaveChanges();
            }
            var Plat = new Platter()
            {
                PlatterNo = platId,
                Description = Desc,
                Siteid = 1,
                ActualAmount = ActualAmount,
                RebateAmount = RebutAmount,
                NetAmount = NetAmount,
                TotalAreaSize = ActualSize,
                IsActive = true
            };
            db.Platter.Add(Plat);
            db.SaveChanges();
            if (HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList") != null)
            {
                HttpContext.Session.Clear();
                HttpContext.Session.Remove("PlatterList");
            }
            if (platId != null)
            {
                platId = null;
            }
            platName = null;
            platAmount = null;
            return RedirectToAction("Filter", "File");
        }
        public IActionResult Cancle()
        {
            if (HttpContext.Session.GetObject<List<AddPlatterVM>>("PlatterList") != null)
            {
                HttpContext.Session.Clear();
                HttpContext.Session.Remove("PlatterList");
            }
            if (platId != null)
            {
                platId = null;
            }
            platName = null;
            platAmount = null;
            return RedirectToAction("Filter", "File");
        }
    }
}
