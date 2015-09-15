using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TOCGOJS.Models;

namespace TOCGOJS.Context
{
    public class TOCdb : DbContext
    {
        public TOCdb() : base("TOCDatabase")
        {
            Database.SetInitializer<TOCdb>(new CreateDatabaseIfNotExists<TOCdb>());
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<CurrentRealityTree> CurrentRealityTree { get; set; }
        public DbSet<Cloud> Cloud { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Project>()
                .HasMany(t => t.CurrentRealityTrees);

        }
    }
}