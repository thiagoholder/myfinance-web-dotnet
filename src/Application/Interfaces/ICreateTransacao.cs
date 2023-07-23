using MyFinance.Application.Dto;

namespace MyFinance.Application.Interfaces;

public interface ICreateTransacao
{
    Task ExecuteAsync(Transacao transacao);
}