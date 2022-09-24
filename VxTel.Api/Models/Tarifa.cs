using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace VxTel.Api.Models;

[Index(nameof(IdCidadeOrigem), nameof(IdCidadeDestino), IsUnique = true)]
public class Tarifa
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public int IdCidadeOrigem { get; set; }
    [Required]
    public int IdCidadeDestino { get; set; }
    [Required]
    public float Valor { get; set; }
    [JsonIgnore]
    public virtual Cidade CidadeOrigem { get; set; }
    [JsonIgnore]
    public virtual Cidade CidadeDestino { get; set; }
}