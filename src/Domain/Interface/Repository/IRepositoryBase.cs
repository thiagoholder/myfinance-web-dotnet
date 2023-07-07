
namespace Domain.Interface.Repository;

public class IRepositoryBase<T> where T : class
{
    public async Task<T> GetAsync(Guid id);

    public async Task<IEnumerable<T>> GetAllAsync();

    public async Task CreateAsync(T entity);

    public async Task UpdateAsync(T entity);

    public async Task DeleteAsync(T entity);
}