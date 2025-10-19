using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiMicroservicio.Core.Interfaces;
using MiMicroservicio.Core.Models;

namespace MiMicroservicio.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Autenticar(Usuario usuario)
        {            
            // En producción, se debe validar contra una base de datos.
            if (usuario.Username == "admin" && usuario.Password == "1234")
                usuario.Rol = "Admin";
            else if (usuario.Username == "supervisor" && usuario.Password == "1234")
                usuario.Rol = "Supervisor";
            else if (usuario.Username == "invitado" && usuario.Password == "1234")
                usuario.Rol = "Invitado";
            else
                return null;          
           

            var claims = new[]
            {
               new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Rol),
                new Claim("CustomClaim", "AccesoAutorizado-" + usuario.Rol)               
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
    }
}
