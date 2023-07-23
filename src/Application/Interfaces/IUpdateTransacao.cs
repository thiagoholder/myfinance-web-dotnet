using MyFinance.Application.Dto;

namespace MyFinance.Application.Interfaces;

public interface IUpdateTransacao
{
    Task ExecuteAsync(Transacao transacao);
}