using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_MyTimeTracker.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}