using Domain.Models;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Services;

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

    public async Task DeletePlanoContaAsync(int id)
    {
        var planoConta = await this.GetPlanoContaAsync(id);
        if(planoConta != null) { await _planoContaRepository.DeleteAsync(planoConta); }
        
    }

    public async Task<IEnumerable<PlanoConta>> GetAllPlanosContasAsync()
    {
       return await _planoContaRepository.GetAllAsync();
    }

    public async Task<PlanoConta> GetPlanoContaAsync(int id)
    {
        return await _planoContaRepository.GetAsync(id);
    }

    public async Task UpdatePlanoContaAsync(PlanoConta planoConta)
    {
        await _planoContaRepository.UpdateAsync(planoConta);
    }
}
