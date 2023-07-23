using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;

namespace MyFinance.Application.TransacaoUserCase;

public class DeleteTrancao : IDeleteTransacao
{
    private readonly ITransacaoService _transacaoService;

    public DeleteTrancao(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    public async Task ExecuteAsync(Guid id)
    {
       await _transacaoService.DeteleTransacaoAsync(id);
    }
}