using System.ComponentModel.DataAnnotations;

namespace Musique.Models;

public class Seguidores
{

    [Key]
    public int IdSeguidor { get; set; }

    [Key]
    public int IdSeguido { get; set; }

}