using MiMicroservicio.Core.Interfaces;
using MiMicroservicio.Core.Models;
using MiMicroservicio.Infrastructure.Data;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MiMicroservicio.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(MongoDbContext context)
        {
            _usuarios = context.Usuarios; 
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.Username, username);
            return await _usuarios.Find(filter).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }
    }
}
