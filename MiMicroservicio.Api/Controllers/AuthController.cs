using Microsoft.AspNetCore.Mvc;
using MiMicroservicio.Infrastructure.Services;

namespace MiMicroservicio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Username, request.Password);
            if (token == null)
                return Unauthorized(new { message = "Credenciales inválidas" });

            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            await _authService.RegistrarAsync(request.Username, request.Password, request.Role);
            return Ok(new { message = "Usuario creado exitosamente" });
        }
    }

    public record LoginRequest(string Username, string Password);
    public record RegisterRequest(string Username, string Password, string Role);
}
