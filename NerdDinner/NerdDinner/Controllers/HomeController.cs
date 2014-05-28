using NerdDinner.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace NerdDinner.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int page = 1)
        {
            var model = db.Meetings.Include("Users").OrderByDescending(m => m.Users.Count()).ToPagedList(page, 3);
            ViewBag.ColorPicker = new List<string> { "panel-danger", "panel-success", "panel-info" };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}