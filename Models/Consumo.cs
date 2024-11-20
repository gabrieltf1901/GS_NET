namespace SustainableEnergyProject.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Consumo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DataHora { get; set; } = DateTime.Now;

    [Required]
    public double ValorConsumo { get; set; }

    [ForeignKey("Dispositivo")]
    public int? IdDispositivo { get; set; }
    public Dispositivo Dispositivo { get; set; }

    [ForeignKey("Usuario")]
    public int? IdUsuario { get; set; }
    public Usuario Usuario { get; set; }
}
