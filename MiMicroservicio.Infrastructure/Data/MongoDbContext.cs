using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MiMicroservicio.Core.Models;


namespace MiMicroservicio.Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");
     public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("Usuarios");
}