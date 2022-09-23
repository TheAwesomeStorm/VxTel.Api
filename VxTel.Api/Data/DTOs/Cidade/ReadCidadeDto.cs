using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Cidade;

public class ReadCidadeDto
{
    [Key][Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public int CodigoDdd { get; set; }
}