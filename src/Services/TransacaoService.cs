using MyFinance.Domain.Interfaces.Repositories;
using MyFinance.Domain.Interfaces.Services;
using MyFinance.Domain.Models;

namespace MyFinance.Services;

public class TransacaoService : ITransacaoService
{
    protected ITransacaoRepository _transacaoRepository;

    public TransacaoService(ITransacaoRepository transacaoRepository)
    {
        _transacaoRepository = transacaoRepository;
    }

    public async Task CreateTransacaoAsync(Transacao transacao)
    {
        await _transacaoRepository.CreateAsync(transacao);
    }

    public async Task DeteleTransacaoAsync(Guid id)
    {
        var transacao = await this.GetTransacaoAsyn(id);
        if (transacao != null) { await _transacaoRepository.DeleteAsync(transacao); }
    }

    public async Task<IEnumerable<Transacao>> GetAllTransacoesAsync()
    {
        return await _transacaoRepository.GetAllAsync();
    }

    public async Task<Transacao> GetTransacaoAsyn(Guid id)
    {
        return await _transacaoRepository.GetAsync(id);
    }

    public async Task UpdateTransacaAsync(Transacao transacao)
    {
        await _transacaoRepository.UpdateAsync(transacao);
    }
}