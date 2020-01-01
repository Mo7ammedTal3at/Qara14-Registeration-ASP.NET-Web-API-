using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Qara14.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
            : base("DbConnection")
        {
        }

        public DbSet<Recorder> Recorders { get; set; }
        public DbSet<Qarar> Qarars { get; set; }
        public DbSet<Daraga> Daragas { get; set; }
        public DbSet<Rotba> Rotbas { get; set; }
    }
}