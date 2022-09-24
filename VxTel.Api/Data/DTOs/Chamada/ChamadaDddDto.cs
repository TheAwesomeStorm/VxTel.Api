using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Chamada;

public class ChamadaDddDto
{
    [Required]
    public int DuracaoMinutos { get; set; }
    [Required]
    public int DddCidadeOrigem { get; set; }
    [Required]
    public int DddCidadeDestino { get; set; }
}