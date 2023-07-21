namespace MyFinance.Application.Interfaces
{
    public interface IDeletePlanoConta
    {
        Task ExecuteAsync(Guid id);
    }
}


