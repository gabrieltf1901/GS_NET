using Microsoft.AspNetCore.Mvc;
using SustainableEnergyProject.Models;
using SustainableEnergyProject.Repositories;

namespace SustainableEnergyProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecomendacaoController : ControllerBase
{
    private readonly IRepository<Recomendacao> _repository;

    public RecomendacaoController(IRepository<Recomendacao> repository)
    {
        _repository = repository;
    }

    [HttpGet("tipo/{tipo}")]
    public async Task<ActionResult<IEnumerable<Recomendacao>>> GetByTipo(string tipo)
    {
        return Ok(await ((RecomendacaoRepository)_repository).GetByTipoAsync(tipo));
    }

    [HttpGet("usuario/{userId}")]
    public async Task<ActionResult<IEnumerable<Recomendacao>>> GetByUsuario(int userId)
    {
        return Ok(await ((RecomendacaoRepository)_repository).GetByUsuarioAsync(userId));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Recomendacao recomendacao)
    {
        await _repository.AddAsync(recomendacao);
        return CreatedAtAction(nameof(GetByUsuario), new { userId = recomendacao.IdUsuario }, recomendacao);
    }
}
