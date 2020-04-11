using Konecta.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Konecta.Models.Context
{
    public class KonectaContext : DbContext
    {
        public KonectaContext() : base("name=KonectaDBConnectionString")
        {
            Database.SetInitializer<KonectaContext>(new DropCreateDatabaseIfModelChanges<KonectaContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}