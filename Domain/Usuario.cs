using System.ComponentModel.DataAnnotations;

namespace LocadoraApi.Domain;

public class Usuario
{
    [Key]
    public int Codigo { get; set; }

    public Guid IdentificadorUsuario { get; set; } = Guid.NewGuid();
    
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    public string Senha { get; set; }
    
}