using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VxTel.Api.Models;

public class Cidade
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public int CodigoDdd { get; set; }
    [JsonIgnore]
    public virtual List<Tarifa> TarifasComoOrigem { get; set; }
    [JsonIgnore]
    public virtual List<Tarifa> TarifasComoDestino { get; set; }
}