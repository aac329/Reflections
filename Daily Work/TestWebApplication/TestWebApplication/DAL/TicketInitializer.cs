using System;
using System.Collections.Generic;
using TestWebApplication.Models;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestWebApplication.Models;

namespace TestWebApplication.DAL
{
    public class TicketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TicketContext>
    {
        protected override void Seed(TicketContext context)
        {
            var tickets = new List<Ticket>
            {
            //new Ticket{Title="Fix Google",Description="Google is broken!",DateCreated=DateTime.Parse("2005-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix Bing",Description="Bing is broken!",DateCreated=DateTime.Parse("2005-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix Yahoo",Description="Yahoo is broken!",DateCreated=DateTime.Parse("2003-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix AOL",Description="AOL is broken!",DateCreated=DateTime.Parse("2001-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix Facebook",Description="Facebook is broken!",DateCreated=DateTime.Parse("2001-12-30"),Status="Assigned"},
            //new Ticket{Title="Fix MySpace",Description="MySpace is broken!",DateCreated=DateTime.Parse("2012-01-15"),Status="Assigned"},
            //new Ticket{Title="Fix Amazon",Description="Amazon is broken!",DateCreated=DateTime.Parse("2002-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix Dev",Description="Dev is broken!",DateCreated=DateTime.Parse("2004-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix Test",Description="Test is broken!",DateCreated=DateTime.Parse("2006-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix Prod",Description="Prod is broken!",DateCreated=DateTime.Parse("2007-09-01"),Status="Assigned"},
            //new Ticket{Title="Fix NAU",Description="NAU is broken!",DateCreated=DateTime.Parse("2008-12-30"),Status="Assigned"},
            //new Ticket{Title="Fix Zebras",Description="Zebras is broken!",DateCreated=DateTime.Parse("2014-01-15"),Status="Assigned"}
            };

            tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();
        }
    }
}