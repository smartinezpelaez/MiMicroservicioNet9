using MongoDB.Driver;
using MiMicroservicio.Core.Interfaces;
using MiMicroservicio.Core.Models;
using MiMicroservicio.Infrastructure.Data;


namespace MiMicroservicio.Infrastructure.Repositories;


public class ClienteRepository : IClienteRepository
{
    private readonly MongoDbContext _context;

    public ClienteRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync() =>
        await _context.Clientes.Find(_ => true).ToListAsync();

    public async Task<Cliente?> GetByIdAsync(string id) =>
        await _context.Clientes.Find(c => c.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Cliente cliente) =>
        await _context.Clientes.InsertOneAsync(cliente);

    public async Task UpdateAsync(string id, Cliente cliente) =>
        await _context.Clientes.ReplaceOneAsync(c => c.Id == id, cliente);

    public async Task DeleteAsync(string id) =>
        await _context.Clientes.DeleteOneAsync(c => c.Id == id);

}