using CustomerCare.Application.Interfaces;
using CustomerCare.Application.Models;
using CustomerCare.Application.Services;
using CustomerCare.Domain.Entities;
using FluentValidation;
using Moq;

namespace CustomerCare.UnitTests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Create_User_WithSuccess()
        {
            //Arrange
            var request = new CreateUserRequest
            {
                Cpf = "48135338503",
                Password = "My$trongPassw0rd",
                Name = "John Doe",
                Email = "myemail@emailservice.com",
                Phone = "11944554455",
                Address = new() {
                    Street = "Av. Jundiaí",
                    Number = "1234",
                    District = "Anhangabaú",
                    City = "Jundiaí",
                    State = "SP",
                    ZipCode = "13218150"
                }
            };

            var validator = new Mock<IValidator<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(s => s.UserRepository.Create(It.IsAny<User>()))
                .Callback<User>(u => u.Id = 1);
            var service = new UserService(unitOfWork.Object, validator.Object);

            //Act
            var result = await service.Create(request);

            //Assert
            Assert.True(result > 0);
        }
    }
}