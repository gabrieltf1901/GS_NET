using SustainableEnergyProject.Data;
using SustainableEnergyProject.Models;

namespace SustainableEnergyProject.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RecomendacaoRepository : Repository<Recomendacao>
{
    private readonly ApplicationDbContext _context;

    public RecomendacaoRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recomendacao>> GetByTipoAsync(string tipo)
    {
        return await _context.Recomendacoes.Where(r => r.TipoRecomendacao == tipo).ToListAsync();
    }

    public async Task<IEnumerable<Recomendacao>> GetByUsuarioAsync(int userId)
    {
        return await _context.Recomendacoes.Where(r => r.IdUsuario == userId).ToListAsync();
    }
}
