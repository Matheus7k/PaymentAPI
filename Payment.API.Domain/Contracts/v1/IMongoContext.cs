namespace Payment.API.Domain.Contracts.v1
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);
        Task SaveChanges();        
    }
}
