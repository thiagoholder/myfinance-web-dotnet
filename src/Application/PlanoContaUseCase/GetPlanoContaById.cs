using MyFinance.Application.Dto;
using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;

namespace MyFinance.Application;

public class GetPlanoContaById : IGetPlanoContaById
{
    private readonly IPlanoContaService service;

    public GetPlanoContaById(IPlanoContaService planoContaService)
    {
        service = planoContaService;
    }

    public async Task<PlanoConta> ExecuteAsync(Guid id)
    {
        var planoContaDomain = await service.GetPlanoContaAsync(id);
        var planoContaMapper = new PlanoConta
        {
            Id = planoContaDomain.Id,
            Descricao = planoContaDomain.Descricao,
            Tipo = (TipoPlanoConta)planoContaDomain.Tipo
        };

        return planoContaMapper;
    }
}