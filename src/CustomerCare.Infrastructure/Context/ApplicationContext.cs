using Microsoft.EntityFrameworkCore;
using CustomerCare.Application.Interfaces;
using CustomerCare.Domain.Entities;

namespace CustomerCare.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(e => e.Cpf).IsUnique();
            });
        }
    }
}