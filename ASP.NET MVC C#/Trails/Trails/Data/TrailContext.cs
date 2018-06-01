using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trails.Models;
using System.Data.Entity;

namespace Trails.Data
{
    public class TrailContext : DbContext
    {

        public TrailContext(): base() { }

        public DbSet<Zone> Zones { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<Condition> Conditions { get; set; }
    }
}