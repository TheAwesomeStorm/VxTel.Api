using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VxTel.Api.Models;

[Index(nameof(Nome), IsUnique = true)]
public class Plano
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public int Minutos { get; set; }
}