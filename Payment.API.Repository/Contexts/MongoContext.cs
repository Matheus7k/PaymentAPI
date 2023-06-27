using MongoDB.Driver;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Repository.Contexts
{
    public class MongoContext : IMongoContext
    {
        private IClientSessionHandle? _session;
        private readonly List<Func<Task>> _commands;
        private readonly IMongoClient _client;

        public MongoContext(IMongoClient client)
        {
            _client = client;
            _commands = new();
        }

        public async Task SaveChanges()
        {

            using (_session = await _client.StartSessionAsync())
            {
                var commands = _commands.Select(command => command());

                await Task.WhenAll(commands);

                _commands.Clear();
            }

        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}
