using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Ouvinte : Usuario
{

    // [Key]
    // public int IdOuvinte { get; set; }

    [Required]
    public string Genero { get; set; }

    public DateTime DataNascimento { get; set; }

    public int OuvintesSeguidos { get; set; }

    public int Seguidores { get; set; }

    // [ForeignKey("Usuario")]
    // public int IdUsuario { get; set; }
    // public Usuario Usuario { get; set; }

    public ICollection<Avaliacao> Avaliacoes { get; set; }

    public ICollection<Denuncia> Denuncias { get; set; }

    public ICollection<Sugestao> Sugestoes { get; set; }
}