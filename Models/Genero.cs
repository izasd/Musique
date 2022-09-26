using System.ComponentModel.DataAnnotations;

namespace Musique.Models;

public class Genero
{

    [Key]
    public int IdGenero { get; set; }

    [Required, StringLength(64)]
    public string Nome { get; set; }

    public ICollection<Gravacao> Gravacoes { get; set; }
}