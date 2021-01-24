using System;
using System.Threading;
using System.Threading.Tasks;
using DemoPrep.Domain.Entities;
using DemoPrep.Domain.Interfaces;
using DemoPrep.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DemoPrep.Persistance {
    public class ApplicationDbContext : DbContext {
        public DbSet<Unicorn> WeatherForecasts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //apply configuration
            modelBuilder.ApplyConfiguration(new AdminTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UniconrTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerTypeConfiguration());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            OnBeforeSaving();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving() {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries) {
                if (entry.Entity is IAuditedEntity entity) {
                    var now = DateTime.UtcNow;
                    var userId = GetLoggedInUserId();
                    switch (entry.State) {
                        case EntityState.Modified:
                            entity.ModifiedOn = now;
                            entity.ModifiedBy = userId;
                            break;
                        case EntityState.Added:
                            entity.CreatedOn = now;
                            entity.CreatedBy = userId;
                            entity.ModifiedOn = now;
                            break;
                    }
                }
            }
        }

        private string GetLoggedInUserId() {
            return "adminId";
        }


    }
}
