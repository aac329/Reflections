using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.Models;
using TestWebApplication.DAL;
using PagedList;

namespace TestWebApplication.Controllers
{
    public class TicketController : Controller
    {
        private TicketContext db = new TicketContext();

        // GET: /Ticket/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = sortOrder == "title_desc" ? "title" : "title_desc";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DescriptionSortParm = sortOrder == "description" ? "description_desc" : "description";
            ViewBag.StatusSortParm = sortOrder == "status" ? "status_desc" : "status";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tickets = from s in db.Tickets
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Title.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title":
                    tickets = tickets.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    tickets = tickets.OrderByDescending(s => s.Title);
                    break;
                case "description":
                    tickets = tickets.OrderBy(s => s.Description);
                    break;
                case "description_desc":
                    tickets = tickets.OrderByDescending(s => s.Description);
                    break;
                case "Date":
                    tickets = tickets.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    tickets = tickets.OrderByDescending(s => s.DateCreated);
                    break;
                case "status":
                    tickets = tickets.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    tickets = tickets.OrderByDescending(s => s.Status);
                    break;
                default:
                    tickets = tickets.OrderBy(s => s.ID);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(tickets.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Ticket/Details/5
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

        // GET: /Ticket/Create
        public ActionResult Create()
        {
            var model = new Ticket();
            model.Statuses = new[] 
            { 
                new SelectListItem { Value = "Initial_Review", Text = "Initial Review" },
                new SelectListItem { Value = "Assigned", Text = "Assigned" },
                new SelectListItem { Value = "In_Progress", Text = "In Progress" },
                new SelectListItem { Value = "In_Testing", Text = "In Testing" },
                new SelectListItem { Value = "On_Hold", Text = "On Hold" },
                new SelectListItem { Value = "Final_Review", Text = "Final Review" },
                new SelectListItem { Value = "Closed", Text = "Closed" },
                new SelectListItem { Value = "Backlog", Text = "Backlog" },
                new SelectListItem { Value = "Ongoing", Text = "Ongoing" },
                new SelectListItem { Value = "Cancelled", Text = "Cancelled" }
            };

            model.Status = "Initial Review";
            return View(model);
        }

        // POST: /Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,Description,DateCreated,Status")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: /Ticket/Edit/5
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

        // POST: /Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Title,Description,DateCreated,Status")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: /Ticket/Delete/5
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

        // POST: /Ticket/Delete/5
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
