using MyFinance.Application.Dto;

namespace MyFinance.WebApp.Models;

public class PlanoContaListViewModel
{
    public ICollection<PlanoConta> PlanoContas { get; set; }
}