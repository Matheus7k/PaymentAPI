using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Domain.Contracts.v1;
using Payment.API.Domain.Entities.v1;

namespace Payment.API.Repository.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings) : base(client, settings)
        {
        }
    }
}
