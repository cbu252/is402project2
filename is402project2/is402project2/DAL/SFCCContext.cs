using is402project2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace is402project2.DAL
{
    public class SFCCContext : DbContext
    {
        public SFCCContext() : base("SFCCContext")
        {

        }

        public DbSet<intern> Interns { get; set; }
        public DbSet<program> Programs { get; set; }
        public DbSet<questions> Question { get; set; }
        public DbSet<volunteer> Volunteers { get; set; }
    }
}