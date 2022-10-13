using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Album
{
    [Key]
    public int IdAlbum { get; set; }

    [Required, StringLength(100)]
    public string Nome { get; set; }

    public DateTime DataLancamento { get; set; }

    // [ForeignKey("Artista")]
    // public int IdArtista { get; set; }
    // public Artista Artista { get; set; }

    // [Required]
    public ICollection<Gravacao> Gravacoes { get; set; }

    public ICollection<Artista> Artistas { get; set; }
}