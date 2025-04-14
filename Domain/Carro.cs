using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraApi.Domain;

public class Carro
{
    [Key]
    public int Codigo { get; set; }

    public Guid IdentificadorCarro { get; set; } = Guid.NewGuid();
    
    [Required(ErrorMessage = "O ano é obrigatório.")]
    public int Ano { get; set; }
    
    [Required(ErrorMessage = "A cor é obrigatória.")]
    public string Cor { get; set; }
    
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string DescricaoCarro { get; set; }
    
    public string? Observacoes { get; set; }
    
    public int ReferenciaModeloId { get; set; }
    
    [ForeignKey("ReferenciaModeloId")]
    public Modelo? ReferenciaModelo { get; set; }
}