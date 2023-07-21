using MyFinance.Application.Dto;

namespace MyFinance.Application.Interfaces;

public interface ICreatePlanoConta
{
    Task ExecuteAsync(PlanoConta planoConta);
}