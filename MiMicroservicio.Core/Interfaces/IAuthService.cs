using MiMicroservicio.Core.Models;



namespace MiMicroservicio.Core.Interfaces
{
    public interface IAuthService
    {
        string Autenticar(Usuario usuario);
    }
}