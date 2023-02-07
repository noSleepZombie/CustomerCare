using CustomerCare.Application.Models;

namespace CustomerCare.Application.Interfaces
{
    public interface IUserService
    {
        Task<int> Create(CreateUserRequest request);
    }
}