namespace SustainableEnergyProject.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Nome { get; set; }

    [Required, MaxLength(100)]
    public string Email { get; set; }

    [Required, MaxLength(50)]
    public string Senha { get; set; }

    [Required]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Required, MaxLength(20)]
    public string TipoUsuario { get; set; }
}
