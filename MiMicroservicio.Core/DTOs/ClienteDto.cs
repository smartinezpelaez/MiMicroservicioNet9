namespace MiMicroservicio.Core.DTOs;


public class ClienteDto
{
public string? Id { get; set; }
public string Nombre { get; set; } = null!;
public string Email { get; set; } = null!;
public decimal Saldo { get; set; }
}