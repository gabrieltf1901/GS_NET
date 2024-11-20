using Microsoft.AspNetCore.Mvc;
using SustainableEnergyProject.Models;
using SustainableEnergyProject.Repositories;

namespace SustainableEnergyProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfiguracaoController : ControllerBase
{
    private readonly IRepository<Configuracao> _repository;

    public ConfiguracaoController(IRepository<Configuracao> repository)
    {
        _repository = repository;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<Configuracao>> GetByUsuario(int userId)
    {
        var configuracao = await ((ConfiguracaoRepository)_repository).GetByUsuarioAsync(userId);
        if (configuracao == null) return NotFound();
        return Ok(configuracao);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Configuracao configuracao)
    {
        await _repository.AddAsync(configuracao);
        return CreatedAtAction(nameof(GetByUsuario), new { userId = configuracao.IdUsuario }, configuracao);
    }
}
