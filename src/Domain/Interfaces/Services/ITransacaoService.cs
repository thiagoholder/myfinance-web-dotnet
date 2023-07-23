using MyFinance.Domain.Models;

namespace MyFinance.Domain.Interfaces.Services;

public interface ITransacaoService
{
    Task<Transacao> GetTransacaoAsyn(Guid id);
    Task<IEnumerable<Transacao>> GetAllTransacoesAsync();
    Task CreateTransacaoAsync(Transacao transacao);
    Task UpdateTransacaAsync(Transacao transacao);
    Task DeteleTransacaoAsync(Guid id);
    Task<bool> IsPlanoContaAssociatedWithTransacao(Guid id);
}