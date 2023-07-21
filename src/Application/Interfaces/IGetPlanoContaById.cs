using MyFinance.Application.Dto;

namespace MyFinance.Application.Interfaces
{
    public interface IGetPlanoContaById
    {
        Task<PlanoConta> ExecuteAsync(Guid id);
    }
}