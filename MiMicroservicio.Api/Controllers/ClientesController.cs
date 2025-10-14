using Microsoft.AspNetCore.Mvc;
using MiMicroservicio.Core.Interfaces;
using MiMicroservicio.Core.Models;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteRepository _repo;

    public ClientesController(IClienteRepository repo)
    {
        _repo = repo;
    }

    // GET: api/clientes
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    // GET: api/clientes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var c = await _repo.GetByIdAsync(id);
        if (c == null) return NotFound(new { message = $"Cliente con id '{id}' no encontrado." });
        return Ok(c);
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _repo.CreateAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
    }

    // PUT: api/clientes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return NotFound();
        cliente.Id = id;
        await _repo.UpdateAsync(id, cliente);
        return NoContent();
    }

    // DELETE: api/clientes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return NotFound(new { message = $"Cliente con id '{id}' no encontrado." });
        await _repo.DeleteAsync(id);
        return NoContent();
    }


}