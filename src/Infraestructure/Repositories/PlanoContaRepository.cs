using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class PlanoContaRepository : RepositoryBase<PlanoConta>, IPlanoContaRepository
{
    public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
    {
    }
}