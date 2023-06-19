using MongoDB.Driver;
using Payment.API.Domain.Commands.Payment.v1;
using Payment.API.Domain.Contexts.v1;
using Payment.API.Domain.Contracts.v1;
using Payment.API.Domain.Queries.Payment.v1.List;
using Payment.API.Repository;
using Payment.API.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoSettings = configuration.GetSection(nameof(MongoRepositorySettings));
var clientSettings = MongoClientSettings.FromConnectionString(mongoSettings.Get<MongoRepositorySettings>().ConnectionString);
builder.Services.Configure<MongoRepositorySettings>(mongoSettings);
builder.Services.AddSingleton<IMongoClient>(new MongoClient(clientSettings));
builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<PaymentContext>();
builder.Services.AddScoped<PaymentCommandHandler>();
builder.Services.AddScoped<ListPaymentQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
