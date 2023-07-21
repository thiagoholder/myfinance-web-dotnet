using MyFinance.Application.Interfaces;
using MyFinance.Domain;
using MyFinance.Domain.Interfaces.Services;
using MyFinance.Domain.Models;
using DTO = MyFinance.Application.Dto;

namespace MyFinance.Application;

public class CreatePlanoConta : ICreatePlanoConta
{
    private readonly IPlanoContaService _planoContaService;

    public CreatePlanoConta(IPlanoContaService planoContaService)
    {
        _planoContaService = planoContaService;
    }

    public async Task ExecuteAsync(DTO.PlanoConta planoConta)
    {
        var planoContaDomain = new PlanoConta(planoConta.Descricao, (TipoPlanoConta)planoConta.Tipo);
        await _planoContaService.CreatePlanoContaAsync(planoContaDomain);
    }
}