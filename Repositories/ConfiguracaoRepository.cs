using Microsoft.EntityFrameworkCore;
using SustainableEnergyProject.Data;
using SustainableEnergyProject.Models;

namespace SustainableEnergyProject.Repositories;

using System.Threading.Tasks;

public class ConfiguracaoRepository : Repository<Configuracao>
{
    private readonly ApplicationDbContext _context;

    public ConfiguracaoRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Configuracao> GetByUsuarioAsync(int userId)
    {
        return await _context.Configuracoes.FirstOrDefaultAsync(c => c.IdUsuario == userId);
    }
}
