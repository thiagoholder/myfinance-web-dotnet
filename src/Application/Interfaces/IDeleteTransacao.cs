namespace MyFinance.Application.Interfaces
{
    public interface IDeleteTransacao
    {
        Task ExecuteAsync(Guid id);
    }
}