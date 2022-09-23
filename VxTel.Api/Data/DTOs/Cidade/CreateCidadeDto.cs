using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Cidade;

public class CreateCidadeDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public int CodigoDdd { get; set; }
}