namespace SustainableEnergyProject.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Configuracao
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double TarifaEnergia { get; set; }

    [Required]
    public double TempoConsumo { get; set; }

    [ForeignKey("Usuario")]
    public int? IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
}
