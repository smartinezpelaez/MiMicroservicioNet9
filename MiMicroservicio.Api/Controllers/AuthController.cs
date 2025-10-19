using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using MiMicroservicio.Core.Interfaces;
using MiMicroservicio.Core.Models;

namespace MiMicroservicio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

       [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var token = _authService.Autenticar(usuario);
            if (token == null)
                return Unauthorized("Credenciales inválidas");

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var claims = jwt.Claims.Select(c => new { c.Type, c.Value });

            return Ok(new
            {
                token,
                rol = usuario.Rol,
                claims
            });
        }
       
       
       

       
       

       
       
    }
}
