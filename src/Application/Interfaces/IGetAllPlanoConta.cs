using MyFinance.Application.Dto;


namespace MyFinance.Application.Interfaces
{
	public interface IGetAllPlanoConta
	{
		Task<IEnumerable<PlanoConta>> ExecuteAsync(); 
	}
}

