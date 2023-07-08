using Domain.Interface.Repository;
using Domain.Model;

namespace Infraestructure.Repository;

public class PlanoContaRepository : RepositoryBase<PlanoConta>, IPlanoContaRepository
{
    public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
    {
    }
}