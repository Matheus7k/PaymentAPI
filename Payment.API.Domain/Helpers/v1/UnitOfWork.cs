using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Helpers.v1
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _mongoContext;
        
        public UnitOfWork(IMongoContext context)
        {
            _mongoContext = context;
        }

        public async Task Commit()
        {
            await _mongoContext.SaveChanges();
        }
    }
}
