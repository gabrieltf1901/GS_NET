using SustainableEnergyProject.Models;
using SustainableEnergyProject.Repositories;

namespace SustainableEnergyProject.Controllers;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ConsumoController : ControllerBase
{
    private readonly IRepository<Consumo> _repository;

    public ConsumoController(IRepository<Consumo> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consumo>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Consumo>> GetById(int id)
    {
        var consumo = await _repository.GetByIdAsync(id);
        if (consumo == null) return NotFound();
        return Ok(consumo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Consumo consumo)
    {
        await _repository.AddAsync(consumo);
        return CreatedAtAction(nameof(GetById), new { id = consumo.Id }, consumo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Consumo consumo)
    {
        if (id != consumo.Id) return BadRequest();
        await _repository.UpdateAsync(consumo);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("dispositivo/{dispositivoId}")]
    public async Task<ActionResult<IEnumerable<Consumo>>> GetByDispositivo(int dispositivoId)
    {
        return Ok(await ((ConsumoRepository)_repository).GetByDispositivoAsync(dispositivoId));
    }

    [HttpGet("usuario/{userId}")]
    public async Task<ActionResult<IEnumerable<Consumo>>> GetByUsuario(int userId)
    {
        return Ok(await ((ConsumoRepository)_repository).GetByUsuarioAsync(userId));
    }

    [HttpGet("date-range")]
    public async Task<ActionResult<IEnumerable<Consumo>>> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        return Ok(await ((ConsumoRepository)_repository).GetByDateRangeAsync(startDate, endDate));
    }
}
