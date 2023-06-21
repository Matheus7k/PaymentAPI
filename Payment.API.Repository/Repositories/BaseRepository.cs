using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private readonly IMongoCollection<TEntity> _repository;

        public BaseRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _repository = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.Find(payment => true).ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _repository.InsertOneAsync(entity);
        }
    }
}
