using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;

namespace MyFinance.Application;

public class DeletePlanoConta : IDeletePlanoConta
{
    private readonly IPlanoContaService _planoContaService;

    public DeletePlanoConta(IPlanoContaService planoContaService)
    {
        _planoContaService = planoContaService;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _planoContaService.DeletePlanoContaAsync(id);
    }
}