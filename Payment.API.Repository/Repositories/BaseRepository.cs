using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Repository.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private readonly IMongoCollection<TEntity> _repository;
        private readonly IMongoContext _mongoContext;

        public BaseRepository(IMongoClient client, IOptions<MongoRepositorySettings> settings, IMongoContext mongoContext)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _repository = database.GetCollection<TEntity>(typeof(TEntity).Name);
            _mongoContext = mongoContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.Find(payment => true).ToListAsync();
        }

        public void InsertAsync(TEntity entity)
        {
            _mongoContext.AddCommand(() => _repository.InsertOneAsync(entity));
        }

        public void DeleteAsync(TEntity entity1)
        {
            _mongoContext.AddCommand(() => _repository.FindOneAndDeleteAsync(entity => entity.Equals(entity1)));
        }
    }
}
