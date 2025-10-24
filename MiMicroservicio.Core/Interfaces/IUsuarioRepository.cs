using MiMicroservicio.Core.Models;
using System.Threading.Tasks;

namespace MiMicroservicio.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByUsernameAsync(string username);
        Task AddUserAsync(Usuario usuario);
    }
}
