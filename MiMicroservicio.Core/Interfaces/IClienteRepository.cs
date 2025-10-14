using MiMicroservicio.Core.Models;


namespace MiMicroservicio.Core.Interfaces;

public interface IClienteRepository
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(string id);
    Task CreateAsync(Cliente cliente);
    Task UpdateAsync(string id, Cliente cliente);
    Task DeleteAsync(string id);

}