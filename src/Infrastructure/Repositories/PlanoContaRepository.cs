using MyFinance.Domain.Interfaces.Repositories;
using MyFinance.Domain.Models;
using MyFinance.Infrastructure.Repositories;

namespace MyFinance.Infrastructure.Repositories;

public class PlanoContaRepository : RepositoryBase<PlanoConta>, IPlanoContaRepository
{
    public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
    {
    }
}