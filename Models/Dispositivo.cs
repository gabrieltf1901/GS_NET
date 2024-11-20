namespace SustainableEnergyProject.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Dispositivo
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; }

    [Required, MaxLength(20)]
    [RegularExpression("Real|Simulado", ErrorMessage = "Tipo deve ser 'Real' ou 'Simulado'")]
    public string Tipo { get; set; }

    public double? Potencia { get; set; }

    [Required, MaxLength(10)]
    [RegularExpression("Ativo|Inativo", ErrorMessage = "Status deve ser 'Ativo' ou 'Inativo'")]
    public string Status { get; set; }

    [ForeignKey("Usuario")]
    public int? IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
}
