using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Status> Status { get; }
        Task<int> SaveChangesAync(CancellationToken cancellationToken);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }
}
