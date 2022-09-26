using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Moderador : Usuario
{

    // [Key]
    // public int IdModerador { get; set; }

    [Required]
    public string Tipo { get; set; }

    // [ForeignKey("Usuario")]
    // public int IdUsuario { get; set; }
    // public Usuario Usuario { get; set; }

    public ICollection<Denuncia> Denuncias { get; set; }
}