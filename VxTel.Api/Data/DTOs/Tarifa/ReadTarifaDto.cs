using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Tarifa;

public class ReadTarifaDto
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public Models.Cidade CidadeOrigem { get; set; }
    [Required]
    public Models.Cidade CidadeDestino { get; set; }
    [Required]
    public float Valor { get; set; }
}