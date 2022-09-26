using System.ComponentModel.DataAnnotations;

namespace Musique.Models;

public class Musica
{
    [Key]
    public int IdMusica { get; set; }

    [Required, StringLength(100)]
    public string Nome { get; set; }

    [Required, StringLength(5000)]
    public string Letra { get; set; }

    public ICollection<Gravacao> Gravacoes { get; set; }
}