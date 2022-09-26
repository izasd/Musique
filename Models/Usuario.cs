using System.ComponentModel.DataAnnotations;

namespace Musique.Models;

public class Usuario
{

    [Key]
    public int IdUsuario { get; set; }

    [Required, StringLength(128)]
    public string Nome { get; set; }

    [Required, StringLength(128)]
    public string Email { get; set; }

    [Required, StringLength(20)]
    public string Senha { get; set; }

    [Required, StringLength(20)]
    public string Telefone { get; set; }

    
}