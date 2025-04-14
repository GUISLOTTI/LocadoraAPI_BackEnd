using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraApi.Domain;

public class Locacao
{
    [Key] public int Codigo { get; set; }

    [Required(ErrorMessage = "O identificador do carro é obrigatório.")]
    public int IdentificadorCarroId { get; set; }
    public Carro? IdentificadorCarro { get; set; }

    [Required(ErrorMessage = "O identificador do usuário é obrigatório.")]
    public int IdentificadorUsuarioId { get; set; }
    public Usuario? IdentificadorUsuario { get; set; }

    [Required(ErrorMessage = "A data de retirada é obrigatória.")]
    public DateTime DataRetirada { get; set; }

    [Required(ErrorMessage = "A data de devolução é obrigatória.")]
    public DateTime DataDevolucao { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório.")]
    public decimal Valor { get; set; }

    public string? Observacoes { get; set; }
    
}