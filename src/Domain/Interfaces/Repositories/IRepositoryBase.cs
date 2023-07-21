
namespace MyFinance.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity: class
{
    public Task<TEntity> GetAsync(Guid id);

    public Task<IEnumerable<TEntity>> GetAllAsync();

    public  Task CreateAsync(TEntity entity);

    public  Task UpdateAsync(TEntity entity);

    public Task DeleteAsync(TEntity entity);
}