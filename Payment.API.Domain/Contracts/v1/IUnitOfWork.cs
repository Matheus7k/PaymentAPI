namespace Payment.API.Domain.Contracts.v1
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
