using SustainableEnergyProject.Models;

namespace SustainableEnergyProject.Data;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Dispositivo> Dispositivos { get; set; }
    public DbSet<Consumo> Consumos { get; set; }
    public DbSet<Configuracao> Configuracoes { get; set; }
    public DbSet<Recomendacao> Recomendacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
