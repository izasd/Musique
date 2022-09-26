using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Gravacao
{

    [Key]
    public int IdGravacao { get; set; }

    public DateTime DataLancamento { get; set; }

    public double Duracao { get; set; }

    [ForeignKey("Artista")]
    public int IdArtista { get; set; }
    public Artista Artista { get; set; }

    [ForeignKey("Genero")]
    public int IdGenero { get; set; }
    public Genero Genero { get; set; }

    [ForeignKey("Musica")]
    public int IdMusica { get; set; }
    public Musica Musica { get; set; }

    [ForeignKey("Album")]
    public int IdAlbum { get; set; }
    public Album Album { get; set; }

    public ICollection<Avaliacao> Avaliacoes { get; set; }
}