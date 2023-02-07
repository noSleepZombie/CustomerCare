namespace CustomerCare.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task Create(T entity);

    }
}