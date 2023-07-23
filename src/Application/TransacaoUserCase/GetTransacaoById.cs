using MyFinance.Application.Dto;
using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;

namespace MyFinance.Application.TransacaoUserCase;

public class GetTransacaoById : IGetTransacaoById
{
    private readonly ITransacaoService _transacaoService;

    public GetTransacaoById(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public async Task<Transacao?> ExecuteAsync(Guid id)
    {
        var transacaoDomain = await _transacaoService.GetTransacaoAsyn(id);

        return transacaoDomain == null
            ? null
            : new Transacao
            {
                Id = transacaoDomain.Id,
                Data = transacaoDomain.Data,
                Historico = transacaoDomain.Historico,
                Valor = transacaoDomain.Valor,
                PlanoConta = transacaoDomain.ItemPlanoConta.Descricao,
                PlanoContaId = transacaoDomain.ItemPlanoConta.Id
            };
    }
}