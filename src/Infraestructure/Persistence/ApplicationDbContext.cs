using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Common.Models;

namespace Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Product> Products =>  Set<Product>();
        public DbSet<Status> Status => Set<Status>();

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }


        public async Task<int> SaveChangesAync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .Property(e => e.StatusId)
                .HasConversion<int>();

            builder
                .Entity<Status>()
                .Property(e => e.StatusId)
                .HasConversion<int>();

            base.OnModelCreating(builder);
        }
    }
}
