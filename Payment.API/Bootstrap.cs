using MongoDB.Driver;
using Payment.API.Domain.Commands.Payment.v1;
using Payment.API.Domain.Contracts.v1;
using Payment.API.Repository.Repositories;
using Payment.API.Repository;
using Payment.API.Domain.Queries.Payment.v1.List;
using Payment.API.Domain.Strategies.v1;
using Payment.API.Domain.Contexts.v1;
using Payment.API.Domain.Helpers.v1;

namespace Payment.API
{
    public static class Bootstrap
    {
        public static IServiceCollection AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCommands();
            services.AddQueries();
            services.AddStrategies();
            services.AddContexts();
            services.AddMappers();
            services.AddFactories();
            services.AddRepositories(configuration);
            return services;
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<CreatePaymentCommandHandler>();
        }

        private static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<ListPaymentQuery>();
        }

        private static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CreatePaymentCommandProfile));
        }

        private static void AddStrategies(this IServiceCollection services)
        {
            services.AddScoped<IStrategy, PixStrategy>();
            services.AddScoped<IStrategy, DebitStrategy>();
            services.AddScoped<IStrategy, CreditStrategy>();
            services.AddScoped<IStrategy, TicketStrategy>();
        }

        private static void AddContexts(this IServiceCollection services)
        {
            services.AddScoped<PaymentContext>();
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IPaymentFactory, PaymentFactory>();
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection(nameof(MongoRepositorySettings));
            var clientSettings = MongoClientSettings.FromConnectionString(mongoSettings.Get<MongoRepositorySettings>().ConnectionString);
            services.Configure<MongoRepositorySettings>(mongoSettings);
            services.AddSingleton<IMongoClient>(new MongoClient(clientSettings));
            services.AddSingleton<IPaymentRepository, PaymentRepository>();
        }
    }
}
