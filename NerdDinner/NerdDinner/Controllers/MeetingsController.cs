using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NerdDinner.DAL;
using NerdDinner.Models;
using Microsoft.AspNet.Identity;

namespace NerdDinner.Controllers
{
[Authorize]
    public class MeetingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Meetings
        public async Task<ActionResult> Index()
        {
            string currentUser = User.Identity.GetUserId();
            var meetings = db.Meetings.Include(m => m.Host).Where(m => m.Host.Id == currentUser);
            return View(await meetings.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = await db.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MeetingID,Title,Date,Lat,lng,Description,Address,OwnerID")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                meeting.MeetingID = Guid.NewGuid();
                meeting.OwnerID = User.Identity.GetUserId();
                User attendee = db.Users.Where(u => u.Id == meeting.OwnerID).FirstOrDefault();
                meeting.Attendees.Add(attendee);
                db.Meetings.Add(meeting);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.OwnerID = new SelectList(db.Users, "Id", "UserName", meeting.OwnerID);
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = await db.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.Users, "Id", "UserName", meeting.OwnerID);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MeetingID,Title,Date,Lat,lng,Description,Address,OwnerID")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meeting).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Users, "Id", "UserName", meeting.OwnerID);
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = await db.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Meeting meeting = await db.Meetings.FindAsync(id);
            db.Meetings.Remove(meeting);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Join(Guid id)
        {
            Meeting meeting = await db.Meetings.FindAsync(id);
            if (meeting == null)
            { return HttpNotFound(); }
            return View(meeting);
        }
        [HttpPost]
        public async Task<ActionResult> Join(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = await db.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            else
            {
                string userID = User.Identity.GetUserId();
                User Attendee = db.Users.Where(u => u.Id == userID).FirstOrDefault();
                if (!meeting.Attendees.Contains(Attendee))
                {
                    meeting.Attendees.Add(Attendee);
                    db.Entry(meeting).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    return RedirectToAction("Index", "Home").Danger("You're Already Attending This Dinner!");
                }
            }
            return RedirectToAction("Index", "Home").Success("Your Dinner has been added!");
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
