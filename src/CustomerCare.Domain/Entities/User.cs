namespace CustomerCare.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual Address Address { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}