using MyFinance.Application.Dto;

namespace MyFinance.Application.Interfaces;

public interface IGetAllTransacoes
{
    Task<IEnumerable<Transacao>> ExecuteAsync();
}