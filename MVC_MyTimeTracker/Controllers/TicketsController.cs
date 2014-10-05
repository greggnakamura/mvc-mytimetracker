using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_MyTimeTracker.Models;
using System.Data.Entity.Infrastructure;

namespace MVC_MyTimeTracker.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: /Tickets/
        public ActionResult Index()
        {
            return View(db.Tickets.ToList());
        }

        // GET: /Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: /Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TicketId,Title,Description,DateCreated,DateUpdated")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {

                ticket.DateCreated = DateTime.Now;
                ticket.DateUpdated = DateTime.Now;

                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: /Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: /Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                // get current time
                ticket.DateUpdated = DateTime.Now;

                DbEntityEntry<Ticket> entry = db.Entry(ticket);
                entry.State = EntityState.Unchanged;

                entry.Property(p => p.Title).IsModified = true;
                entry.Property(p => p.Description).IsModified = true;
                entry.Property(p => p.DateUpdated).IsModified = true;
                entry.Property(p => p.ProjectId).IsModified = true;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: /Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: /Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
