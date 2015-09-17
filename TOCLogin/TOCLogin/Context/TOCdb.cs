using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TOCLogin.Models;

namespace TOCLogin.Context
{
    public class TOCdb : IdentityDbContext<ApplicationUser>
    {
        public TOCdb()
            : base("TOCDatabase", throwIfV1Schema: false)
        {
            Database.SetInitializer<TOCdb>(new CreateDatabaseIfNotExists<TOCdb>());
        }

        public static TOCdb Create()
        {
            return new TOCdb();
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<Tree> Tree { get; set; }
        public DbSet<Cloud> Cloud { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Project>()
                .HasMany(t => t.CurrentRealityTrees);

            modelBuilder.Entity<Tree>()
                .HasMany(t => t.Clouds);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }   
    }
}
