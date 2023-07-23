using MyFinance.Application.Dto;

namespace MyFinance.Application.Interfaces;

public interface IGetTransacaoById
{
    Task<Transacao?> ExecuteAsync(Guid id);
}