using MiMicroservicio.Core.Interfaces;
using MiMicroservicio.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MiMicroservicio.Infrastructure.Services
{
    public class AuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<string?> LoginAsync(string username, string password)
        {
            var user = await _usuarioRepository.GetByUsernameAsync(username);
            Console.WriteLine($"Usuario encontrado: {user.Username}");
            Console.WriteLine($"PasswordHash guardado: {user.PasswordHash}");
            Console.WriteLine($"Password ingresado (hash): {HashPassword(password)}");

            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            var role = user.Role.ToLower() switch
            {
                "administrador" or "admin" => "Admin",
                "supervisor" => "Supervisor",
                "usuario" or "user" => "User",
                _ => "User" 
            };

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               claims: claims,
               expires: DateTime.Now.AddHours(1),
               signingCredentials: creds
            );   
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RegistrarAsync(string username, string password, string role)
        {
            string hash = HashPassword(password);
            var user = new Usuario { Username = username, PasswordHash = hash, Role = role };
            await _usuarioRepository.AddUserAsync(user);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private static bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash.Trim();
        }
    }
}
