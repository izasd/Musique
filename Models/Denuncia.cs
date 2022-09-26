using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musique.Models;

public class Denuncia
{

    [Key]
    public int IdDenuncia { get; set; }

    [Required]
    public string OpcMotivo { get; set; }

    public string TextoMotivo { get; set; }

    public EnumEstadoModeracao Estado { get; set; }

    [ForeignKey("Avaliacao")]
    public int IdAvaliacao { get; set; }
    public Avaliacao Avaliacao { get; set; }

    [ForeignKey("Ouvinte")]
    public int IdOuvinte { get; set; }
    public Ouvinte Denunciante { get; set; }
}