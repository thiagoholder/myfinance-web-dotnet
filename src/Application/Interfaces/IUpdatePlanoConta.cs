using MyFinance.Application.Dto;

namespace MyFinance.Application.Interfaces
{
    public interface IUpdatePlanoConta
    {
        Task ExecuteAsync(PlanoConta planoConta);
    }
}