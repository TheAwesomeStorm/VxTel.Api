using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Plano;

public class ReadPlanoDto
{
    [Key][Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required] public int Minutos { get; set; }
}