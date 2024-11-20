using SustainableEnergyProject.Models;
using SustainableEnergyProject.Repositories;

namespace SustainableEnergyProject.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DispositivoController : ControllerBase
{
    private readonly IRepository<Dispositivo> _repository;

    public DispositivoController(IRepository<Dispositivo> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dispositivo>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dispositivo>> GetById(int id)
    {
        var dispositivo = await _repository.GetByIdAsync(id);
        if (dispositivo == null) return NotFound();
        return Ok(dispositivo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Dispositivo dispositivo)
    {
        await _repository.AddAsync(dispositivo);
        return CreatedAtAction(nameof(GetById), new { id = dispositivo.Id }, dispositivo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Dispositivo dispositivo)
    {
        if (id != dispositivo.Id) return BadRequest();
        await _repository.UpdateAsync(dispositivo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<Dispositivo>>> GetByStatus(string status)
    {
        return Ok(await ((DispositivoRepository)_repository).GetByStatusAsync(status));
    }

    [HttpGet("tipo/{tipo}")]
    public async Task<ActionResult<IEnumerable<Dispositivo>>> GetByTipo(string tipo)
    {
        return Ok(await ((DispositivoRepository)_repository).GetByTipoAsync(tipo));
    }

    [HttpGet("usuario/{userId}")]
    public async Task<ActionResult<IEnumerable<Dispositivo>>> GetByUsuario(int userId)
    {
        return Ok(await ((DispositivoRepository)_repository).GetByUsuarioAsync(userId));
    }
}
