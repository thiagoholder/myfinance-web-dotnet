using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;
using MyFinance.Domain.Models;
using DTO = MyFinance.Application.Dto;

namespace MyFinance.Application.TransacaoUserCase;

public class UpdateTransacao : IUpdateTransacao
{
    private readonly ITransacaoService _transacaoService;
    private readonly IPlanoContaService _planoContaService;

    public UpdateTransacao(ITransacaoService transacaoService, IPlanoContaService planoContaService)
    {
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;
    }

    public async Task ExecuteAsync(DTO.Transacao transacao)
    {
        var planodeContaDomain = await _planoContaService.GetPlanoContaAsync(transacao.PlanoContaId);
        var transacaoDomain = new Transacao(transacao.Id, transacao.Data, transacao.Valor, transacao.Historico, planodeContaDomain);
        await _transacaoService.UpdateTransacaAsync(transacaoDomain);
    }
}