using Microsoft.EntityFrameworkCore;
using SustainableEnergyProject.Data;
using SustainableEnergyProject.Models;

namespace SustainableEnergyProject.Repositories;

public class UsuarioRepository : IRepository<Usuario>
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await GetByIdAsync(id);
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<object?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<object?> IsAdminAsync(int id)
    {
        throw new NotImplementedException();
    }
}
