using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;
using MyFinance.Domain.Models;
using DTO = MyFinance.Application.Dto;

namespace MyFinance.Application.TransacaoUserCase;

public class CreateTransacao : ICreateTransacao
{
    private readonly ITransacaoService _transacaoService;
    private readonly IPlanoContaService _planoContaService;

    public CreateTransacao(ITransacaoService transacaoService, IPlanoContaService planoContaService)
    {
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;
    }

    public async Task ExecuteAsync(DTO.Transacao transacao)
    {
        var planoConta = await this._planoContaService.GetPlanoContaAsync(transacao.PlanoContaId);
        var transacaoDomain = new Transacao(transacao.Data, transacao.Valor, transacao.Historico, planoConta);
        await _transacaoService.CreateTransacaoAsync(transacaoDomain);
    }
}