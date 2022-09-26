using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Avaliacao
{

    [Key]
    public int IdAvaliacao { get; set; }

    [Required]
    public int Classificacao { get; set; }

    public string Comentario { get; set; }

    public EnumEstadoModeracao Estado { get; set; }

    [ForeignKey("Ouvinte")]
    public int IdOuvinte { get; set; }
    public Ouvinte Ouvinte { get; set; }

    public ICollection<Denuncia> Denuncias { get; set; }

}