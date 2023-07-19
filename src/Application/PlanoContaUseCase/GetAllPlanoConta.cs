using MyFinance.Application.Dto;
using MyFinance.Domain.Interfaces.Services;
using MyFinance.Application.Interfaces;

namespace MyFinance.Application;

public class GetAllPlanoConta: IGetAllPlanoConta
{
    private readonly IPlanoContaService service;

    public GetAllPlanoConta(IPlanoContaService planoContaService)
    {
        service = planoContaService;
    }

    public async Task<IEnumerable<PlanoConta>> ExecuteAsync()
    {
        var planoContaDomain = await service.GetAllPlanosContasAsync();
        var planoContaMapper = planoContaDomain.Select(x => new PlanoConta
        {
            Id = x.Id,
            Descricao = x.Descricao,
            Tipo = (TipoPlanoConta)x.Tipo
        });

        return planoContaMapper;
    }
}
