using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Interfaces.Repositories;
using MyFinance.Domain.Models;

namespace MyFinance.Infrastructure.Repositories;

public class TransacaoRepository : RepositoryBase<Transacao>, ITransacaoRepository
{
    public TransacaoRepository(MyFinanceDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Transacao>> GetAllAsync()
    {
        return await base.DbSet.Include(t => t.ItemPlanoConta).ToListAsync();
    }
}