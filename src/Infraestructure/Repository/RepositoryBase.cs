using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;


public class RepositoryBase<T>: IRepositoryBase<T> where T : class
{
    protected DbContext DbContext { get; set; }

    public virtual async Task<T> GetAsync(int id) => await DbContext.Set<T>().FindAsync(id);

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await DbContext.Set<T>().ToListAsync();

    public virtual async Task CreateAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }
}