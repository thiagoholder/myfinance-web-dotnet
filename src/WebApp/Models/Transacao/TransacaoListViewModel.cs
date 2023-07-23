using MyFinance.Application.Dto;

namespace MyFinance.WebApp.Models;

public class TransacaoListViewModel
{
    public ICollection<Transacao> Transacoes { get; set; }
}