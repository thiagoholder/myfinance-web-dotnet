using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPlanoContaService
{
    Task<PlanoConta> GetPlanoContaAsync(int id);
    Task<IEnumerable<PlanoConta>> GetAllPlanosContasAsync();
    Task CreatePlanoContaAsync(PlanoConta planoConta);
    Task UpdatePlanoContaAsync(PlanoConta planoConta);
    Task DeletePlanoContaAsync(int id);
}

