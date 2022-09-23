using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VxTel.Api.Models;

public class Tarifa
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public int IdCidadeOrigem { get; set; }
    [JsonIgnore]
    public virtual Cidade CidadeOrigem { get; set; }
    [Required]
    public int IdCidadeDestino { get; set; }
    [JsonIgnore]
    public virtual Cidade CidadeDestino { get; set; }
    [Required]
    public float valor { get; set; }
}