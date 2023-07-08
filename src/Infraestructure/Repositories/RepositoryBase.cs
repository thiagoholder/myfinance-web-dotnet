using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infraestructure.Repositories;


public class RepositoryBase<T>: IRepositoryBase<T> where T : class
{
    protected MyFinanceDbContext _dbContext;

    public RepositoryBase(MyFinanceDbContext dbContext)
    {
       _dbContext = dbContext;
    }

    public virtual async Task<T> GetAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();

    public virtual async Task CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}