using CustomerCare.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IApplicationContext context;
        private readonly DbSet<T> dbSet;
        public Repository(IApplicationContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
        }
    }
}