
namespace Domain.Interface.Repository;

public interface IRepositoryBase<T>
{
    public Task<T> GetAsync(int id);

    public Task<IEnumerable<T>> GetAllAsync();

    public  Task CreateAsync(T entity);

    public  Task UpdateAsync(T entity);

    public Task DeleteAsync(T entity);
}