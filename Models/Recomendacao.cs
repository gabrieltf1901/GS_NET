namespace SustainableEnergyProject.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Recomendacao
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Descricao { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    [Required, MaxLength(20)]
    [RegularExpression("Geral|Baseado", ErrorMessage = "Tipo de recomendação deve ser 'Geral' ou 'Baseado'")]
    public string TipoRecomendacao { get; set; }

    [ForeignKey("Usuario")]
    public int? IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
}
