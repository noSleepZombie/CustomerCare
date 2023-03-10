using CustomerCare.Application.Models;
using CustomerCare.Domain.Entities;

namespace CustomerCare.Application.Mappings
{
    public static class MappingExtensions
    {
        public static User MapToEntity(this CreateUserRequest model)
        {
            return new User
            {
                Cpf = model.Cpf,
                Password = model.Password,
                Email = model.Email,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address?.MapToEntity() ?? new()
            };
        }

        public static Address MapToEntity(this CreateUserAddressRequest model)
        {
            return new Address
            {
                Street = model.Street,
                Number = model.Number,
                District = model.District,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode
            };
        }
    }
}