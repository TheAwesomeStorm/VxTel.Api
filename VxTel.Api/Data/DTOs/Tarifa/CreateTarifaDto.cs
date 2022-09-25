using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Tarifa;

public class CreateTarifaDto
{
    [Required]
    public int IdCidadeOrigem { get; set; }
    [Required]
    public int IdCidadeDestino { get; set; }
    [Required]
    public float Valor { get; set; }
}