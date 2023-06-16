namespace Payment.API.Domain.Contracts.v1
{
    public interface IPaymentRepository
    {
        Task InsertAsync(Entities.v1.Payment payment);
        Task<IEnumerable<Entities.v1.Payment>> GetAllAsync();
    }
}
