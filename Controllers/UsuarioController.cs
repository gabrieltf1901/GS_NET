using SustainableEnergyProject.Models;
using SustainableEnergyProject.Repositories;

namespace SustainableEnergyProject.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IRepository<Usuario> _repository;

    public UsuarioController(IRepository<Usuario> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetById(int id)
    {
        var usuario = await _repository.GetByIdAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuario usuario)
    {
        await _repository.AddAsync(usuario);
        return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Usuario usuario)
    {
        if (id != usuario.Id) return BadRequest();
        await _repository.UpdateAsync(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<Usuario>> GetByEmail(string email)
    {
        var usuario = await ((UsuarioRepository)_repository).GetByEmailAsync(email);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpGet("is-admin/{id}")]
    public async Task<ActionResult<bool>> IsAdmin(int id)
    {
        return Ok(await ((UsuarioRepository)_repository).IsAdminAsync(id));
    }
}
