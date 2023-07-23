using MyFinance.Application.Interfaces;
using MyFinance.Domain.Interfaces.Services;

namespace MyFinance.Application;

public class DeletePlanoConta : IDeletePlanoConta
{
    private readonly IPlanoContaService _planoContaService;
    private readonly ITransacaoService _transacaoService;

    public DeletePlanoConta(IPlanoContaService planoContaService,
        ITransacaoService transacaoService)
    {
        _planoContaService = planoContaService;
        _transacaoService = transacaoService;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await VerifyAssociations(id);
        await _planoContaService.DeletePlanoContaAsync(id);
    }

    private async Task VerifyAssociations(Guid id)
    {
        var isPlanoContaAssociated = await _transacaoService.IsPlanoContaAssociatedWithTransacao(id);
        if (isPlanoContaAssociated)
        {
            throw new Exception("Não é possível excluir o Plano de Conta porque ele está associado a uma ou mais Transações.");
        }
    }
}