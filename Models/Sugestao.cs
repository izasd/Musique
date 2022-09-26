using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Sugestao
{

    [Key]
    public int IdSugestao { get; set; }

    [Required, StringLength(128)]
    public string NomeMusica { get; set; }

    [Required, StringLength(128)]
    public string NomeArtista { get; set; }

    public EnumEstadoModeracao Estado { get; set; }

    [ForeignKey("Ouvinte")]
    public int IdOuvinte { get; set; }
    public Ouvinte Ouvinte { get; set; }
}