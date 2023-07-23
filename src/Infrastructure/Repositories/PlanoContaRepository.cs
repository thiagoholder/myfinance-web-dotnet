using MyFinance.Domain.Interfaces.Repositories;
using MyFinance.Domain.Models;

namespace MyFinance.Infrastructure.Repositories;

public class PlanoContaRepository : RepositoryBase<PlanoConta>, IPlanoContaRepository
{
    public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
    {
    }
}