using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Repository.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IMongoCollection<Domain.Entities.v1.Payment> _paymentRepository;

        public PaymentRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _paymentRepository = database.GetCollection<Domain.Entities.v1.Payment>(typeof(Domain.Entities.v1.Payment).Name);
        }

        public async Task<IEnumerable<Domain.Entities.v1.Payment>> GetAllAsync()
        {
            return await _paymentRepository.Find(payment => true).ToListAsync();
        }

        public async Task InsertAsync(Domain.Entities.v1.Payment payment)
        {
            await _paymentRepository.InsertOneAsync(payment);
        }
    }
}
