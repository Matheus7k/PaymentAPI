using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Repository.Repositories
{
    public class PaymentRepository : BaseRepository<Domain.Entities.v1.Payment>, IPaymentRepository
    {
        public PaymentRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings) : base(client, settings)
        {
        }
    }
}
