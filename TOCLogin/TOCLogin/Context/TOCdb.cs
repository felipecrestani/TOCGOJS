using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web;
using TOCLogin.Models;
using Microsoft.AspNet.Identity;

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

        public IDbSet<Project> Project { get; set; }
        public IDbSet<Tree> Tree { get; set; }
        public IDbSet<Cloud> Cloud { get; set; }
        public IDbSet<SharedEntitie> SharedEntitie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Project>()
                .HasMany(t => t.Trees);

            modelBuilder.Entity<Project>()
                .HasMany(t => t.Clouds);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }

        public override int SaveChanges()
        {
            try
            {

                foreach (var auditableEntity in ChangeTracker.Entries<Entity>())
                {
                    if (auditableEntity.State == EntityState.Added ||
                        auditableEntity.State == EntityState.Modified)
                    {
                        var userId = HttpContext.Current.User.Identity.GetUserId();

                        auditableEntity.Entity.ModifiedOn = DateTime.Now;
                        auditableEntity.Entity.ModifiedBy = userId;

                        if (auditableEntity.State == EntityState.Added)
                        {
                            auditableEntity.Entity.CreatedOn = DateTime.Now;
                            auditableEntity.Entity.CreateBy = userId;
                        }
                        else
                        {
                            auditableEntity.Property(p => p.CreatedOn).IsModified = false;
                            auditableEntity.Property(p => p.CreateBy).IsModified = false;
                        }
                    }
                }

                return base.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                return 0;
            }
        }
    }
}
