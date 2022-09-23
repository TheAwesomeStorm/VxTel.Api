using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Plano;

public class UpdatePlanoDto
{
    [Required]
    public string Nome { get; set; }
    [Required] public int Minutos { get; set; }
}