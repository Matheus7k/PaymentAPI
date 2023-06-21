namespace Payment.API.Domain.Contracts.v1
{
    public interface IBaseRepository<TEntity>
    {
        Task InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
