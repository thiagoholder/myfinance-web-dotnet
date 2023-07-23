using MyFinance.Application.Dto;
using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;

namespace MyFinance.Application.TransacaoUserCase;

public class GetAllTransacao : IGetAllTransacoes
{
    private readonly ITransacaoService _transacaoService;

    public GetAllTransacao(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public async Task<IEnumerable<Transacao>> ExecuteAsync()
    {
        var transacoesDominio = await _transacaoService.GetAllTransacoesAsync();

        if (transacoesDominio == null || !transacoesDominio.Any())
        {
            return Enumerable.Empty<Transacao>();
        }

        var transacoes = transacoesDominio.Select(x => new Transacao
        {
            Id = x.Id,
            Valor = x.Valor,
            Historico = x.Historico,
            Data = x.Data,
            PlanoConta = x.ItemPlanoConta.Descricao,
            PlanoContaId = x.ItemPlanoConta.Id
        }).ToList();

        return transacoes;
    }
}