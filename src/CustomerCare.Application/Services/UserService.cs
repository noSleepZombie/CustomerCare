using CustomerCare.Application.Interfaces;
using CustomerCare.Application.Mappings;
using CustomerCare.Application.Models;
using CustomerCare.Domain.Entities;
using FluentValidation;

namespace CustomerCare.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IValidator<User> validator;
        public UserService(IUnitOfWork unitOfWork, IValidator<User> validator)
        {
            this.unitOfWork = unitOfWork;
            this.validator = validator;
        }

        public async Task<int> Create(CreateUserRequest request)
        {
            User entity = request.MapToEntity();

            await validator.ValidateAndThrowAsync(entity);

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            entity.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);
            entity.Salt = salt;
            entity.CreatedAt = DateTime.Now;

            await unitOfWork.UserRepository.Create(entity);  
            await unitOfWork.CommitAsync();

            return entity.Id;
        }
    }
}