using CustomerCare.Application.Interfaces;
using CustomerCare.Domain.Entities;

namespace CustomerCare.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IApplicationContext context) : base(context)
        {
            
        }
    }
}