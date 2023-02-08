using CustomerCare.Application.Interfaces;
using CustomerCare.Domain.Entities;

namespace CustomerCare.Infrastructure.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(IApplicationContext context) : base(context)
        {
            
        }
    }
}