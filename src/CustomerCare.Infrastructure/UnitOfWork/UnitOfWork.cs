using CustomerCare.Application.Interfaces;
using CustomerCare.Infrastructure.Repositories;

namespace CustomerCare.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationContext context;
        private readonly IUserRepository userRepository;

        public UnitOfWork(IApplicationContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get => userRepository ?? new UserRepository(context);
        }

        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}