using MyFinance.Domain.Models;

namespace MyFinance.Domain.Interfaces.Services;

public interface IPlanoContaService
{
    Task<PlanoConta> GetPlanoContaAsync(Guid id);
    Task<IEnumerable<PlanoConta>> GetAllPlanosContasAsync();
    Task CreatePlanoContaAsync(PlanoConta planoConta);
    Task UpdatePlanoContaAsync(PlanoConta planoConta);
    Task DeletePlanoContaAsync(Guid id);
}

