using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infraestructure.Repositories;

public class PlanoContaRepository : RepositoryBase<PlanoConta>, IPlanoContaRepository
{
    public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
    {
    }
}