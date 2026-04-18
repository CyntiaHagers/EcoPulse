using EcoPulse.Api.Models;
using MongoDB.Driver;
using EcoPulse.Api.Services;

var builder = WebApplication.CreateBuilder(args);

//ESSENCIAL para Docker
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// 🔹 Config Mongo
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// 🔹 Conexão Mongo (ENV + fallback)
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration
        .GetSection("MongoDbSettings")
        .Get<MongoDbSettings>();

    var connectionString = Environment.GetEnvironmentVariable("MONGO_CONN");

    if (string.IsNullOrEmpty(connectionString))
    {
        connectionString = settings?.ConnectionString;
    }

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new Exception("Connection string do MongoDB não configurada.");
    }

    Console.WriteLine("Mongo usando: " +
        (Environment.GetEnvironmentVariable("MONGO_CONN") != null ? "ENV (.env)" : "appsettings"));

    return new MongoClient(connectionString);
});

// 🔹 Services
builder.Services.AddSingleton<DeviceService>();

// 🔹 Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger direto na raiz
app.UseSwagger();
app.UseSwaggerUI();

// 🔹 Controllers
app.MapControllers();

app.Run();