using MyFinance.Domain.Models;
using MyFinance.Domain.Interfaces.Repositories;
using MyFinance.Domain.Interfaces.Services;

namespace MyFinance.Services;

public class PlanoContaService : IPlanoContaService
{
    protected IPlanoContaRepository _planoContaRepository;

    public PlanoContaService(IPlanoContaRepository planoContaRepository)
    {
        _planoContaRepository = planoContaRepository;
    }

    public async Task CreatePlanoContaAsync(PlanoConta planoConta)
    {
       await _planoContaRepository.CreateAsync(planoConta);
    }

    public async Task DeletePlanoContaAsync(Guid id)
    {
        var planoConta = await this.GetPlanoContaAsync(id);
        if(planoConta != null) { await _planoContaRepository.DeleteAsync(planoConta); }
        
    }

    public async Task<IEnumerable<PlanoConta>> GetAllPlanosContasAsync()
    {
       return await _planoContaRepository.GetAllAsync();
    }

    public async Task<PlanoConta> GetPlanoContaAsync(Guid id)
    {
        return await _planoContaRepository.GetAsync(id);
    }

    public async Task UpdatePlanoContaAsync(PlanoConta planoConta)
    {
        await _planoContaRepository.UpdateAsync(planoConta);
    }
}
