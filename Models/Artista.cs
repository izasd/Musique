using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Artista : Usuario
{
    // [Key]
    // public int IdArtista { get; set; }

    [StringLength(300)]
    public string Biografia { get; set; }

    // [ForeignKey("Usuario")]
    // public int IdUsuario { get; set; }
    // public Usuario Usuario { get; set; }

    public ICollection<Album> Albuns { get; set; }
}