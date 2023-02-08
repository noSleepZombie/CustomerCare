namespace CustomerCare.Application.Models
{
    public class CreateUserRequest
    {
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public CreateUserAddressRequest Address { get; set; } = new();
    }
}