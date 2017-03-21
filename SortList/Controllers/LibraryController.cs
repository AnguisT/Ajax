using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SortList.Models;

namespace SortList.Controllers
{
    public class LibraryController : Controller
    {
        private UpdateDataEntities db = new UpdateDataEntities();

        public ActionResult Index()
        {
            SelectList disc = new SelectList(db.disc, "discipline", "discipline", 0);
            ViewBag.Disc = disc;

            var litr = db.litr.Include(l => l.disc);
            return View(litr.ToList());
        }

        public ActionResult GetLibrary(string discipline)
        {
            return PartialView(db.litr.Where(l => l.discipline == discipline).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}