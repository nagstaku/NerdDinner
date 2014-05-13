using NerdDinner.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerdDinner.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewData["PopularDinners"] = db.Meetings.Select(m => m).Take(3);
            ViewBag.ColorPicker = new List<string> { "panel-danger", "panel-success", "panel-info" };
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}