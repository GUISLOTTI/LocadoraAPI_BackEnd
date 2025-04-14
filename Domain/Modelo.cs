using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Replication.TestDecoding;

namespace LocadoraApi.Domain;

public class Modelo
{
    [Key] public int Codigo { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string NomeModelo { get; set; }

    public int ReferenciaMarcaId { get; set; }
    
    [ForeignKey("ReferenciaMarcaId")]
    public Marca ReferenciaMarca { get; set; }
}