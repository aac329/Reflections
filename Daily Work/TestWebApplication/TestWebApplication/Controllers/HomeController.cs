using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.DAL;
using TestWebApplication.ViewModels;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private TicketContext db = new TicketContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<TicketDateGroup> data = from ticket in db.Tickets
                                                   group ticket by ticket.DateCreated into dateGroup
                                                   select new TicketDateGroup()
                                                   {
                                                       DateCreated = dateGroup.Key,
                                                       TicketCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Programs()
        {
            return View();
        }
    }
}