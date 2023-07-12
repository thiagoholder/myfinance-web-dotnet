using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;


public abstract class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity : EntityBase, new ()
{
    protected DbContext Db;
    protected DbSet<TEntity> DbSetContext;

    protected RepositoryBase(DbContext dbContext)
    {
       Db = dbContext;
       DbSetContext = Db.Set<TEntity>();
    }

    public virtual async Task<TEntity> GetAsync(int id) => await DbSetContext.FirstAsync(x => x.Id == id);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await DbSetContext.ToListAsync();

    public virtual async Task CreateAsync(TEntity entity)
    {
        DbSetContext.Add(entity);
        await Db.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        DbSetContext.Attach(entity);
        Db.Entry(entity).State = EntityState.Modified;
        await Db.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        Db.Set<TEntity>().Remove(entity);
        await Db.SaveChangesAsync();
    }
}