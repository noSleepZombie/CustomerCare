namespace CustomerCare.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAddressRepository AddressRepository { get; }
        Task CommitAsync();
    }
}