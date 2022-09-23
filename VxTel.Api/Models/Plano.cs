using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Models;

public class Plano
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public int Minutos { get; set; }
}