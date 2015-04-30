using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestWebApplication.DAL
{
    public class TicketContext : DbContext
    {
        public TicketContext() : base("TicketContext")
        { }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}