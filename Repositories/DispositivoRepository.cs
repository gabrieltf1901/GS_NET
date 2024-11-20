using SustainableEnergyProject.Data;
using SustainableEnergyProject.Models;

namespace SustainableEnergyProject.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DispositivoRepository : Repository<Dispositivo>
{
    private readonly ApplicationDbContext _context;

    public DispositivoRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Dispositivo>> GetByStatusAsync(string status)
    {
        return await _context.Dispositivos.Where(d => d.Status == status).ToListAsync();
    }

    public async Task<IEnumerable<Dispositivo>> GetByTipoAsync(string tipo)
    {
        return await _context.Dispositivos.Where(d => d.Tipo == tipo).ToListAsync();
    }

    public async Task<IEnumerable<Dispositivo>> GetByUsuarioAsync(int userId)
    {
        return await _context.Dispositivos.Where(d => d.IdUsuario == userId).ToListAsync();
    }
}
