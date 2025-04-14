using System.ComponentModel.DataAnnotations;

namespace LocadoraApi.Domain;

public class Marca
{
    [Key]
    public int Codigo { get; set; }
    
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string NomeMarca { get; set; }
    

}