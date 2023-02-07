namespace CustomerCare.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task CommitAsync();
    }
}