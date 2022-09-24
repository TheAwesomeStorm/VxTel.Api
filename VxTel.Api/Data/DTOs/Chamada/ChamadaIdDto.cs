using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Chamada;

public class ChamadaIdDto
{
    [Required]
    public int DuracaoMinutos { get; set; }
    [Required]
    public int IdCidadeOrigem { get; set; }
    [Required]
    public int IdCidadeDestino { get; set; }
}