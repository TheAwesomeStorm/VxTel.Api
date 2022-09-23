using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VxTel.Api.Models;

public class Tarifa
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public int IdCidadeOrigem { get; set; }
    public virtual Cidade CidadeOrigem { get; set; }
    [Required]
    public int IdCidadeDestino { get; set; }
    public virtual Cidade CidadeDestino { get; set; }
    [Required]
    public float valor { get; set; }
}