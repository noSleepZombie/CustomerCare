using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}