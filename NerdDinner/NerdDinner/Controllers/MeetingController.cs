using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Models;
using NerdDinner.DAL;
using Microsoft.AspNet.Identity;

namespace NerdDinner.Controllers
{
    public class MeetingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Meeting/
        public ActionResult Index()
        {
            var meetings = db.Meetings.Include(m => m.Owner);
            return View(meetings.ToList());
        }

        // GET: /Meeting/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // GET: /Meeting/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /Meeting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeetingID,Title,Date,Lat,lng,Description,OwnerID")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                meeting.MeetingID = Guid.NewGuid();
                meeting.OwnerID = User.Identity.GetUserId();
                db.Meetings.Add(meeting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meeting);
        }

        // GET: /Meeting/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: /Meeting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeetingID,Title,Date,Lat,lng,Description,OwnerID")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meeting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Users, "Id", "UserName", meeting.OwnerID);
            return View(meeting);
        }

        // GET: /Meeting/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: /Meeting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Meeting meeting = db.Meetings.Find(id);
            db.Meetings.Remove(meeting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
