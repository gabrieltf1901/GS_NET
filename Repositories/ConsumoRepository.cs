using SustainableEnergyProject.Data;
using SustainableEnergyProject.Models;

namespace SustainableEnergyProject.Repositories;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ConsumoRepository : Repository<Consumo>
{
    private readonly ApplicationDbContext _context;

    public ConsumoRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Consumo>> GetByDispositivoAsync(int dispositivoId)
    {
        return await _context.Consumos.Where(c => c.IdDispositivo == dispositivoId).ToListAsync();
    }

    public async Task<IEnumerable<Consumo>> GetByUsuarioAsync(int userId)
    {
        return await _context.Consumos.Where(c => c.IdUsuario == userId).ToListAsync();
    }

    public async Task<IEnumerable<Consumo>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Consumos
            .Where(c => c.DataHora >= startDate && c.DataHora <= endDate)
            .ToListAsync();
    }
}
