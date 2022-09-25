using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VxTel.Api.Models;

[Index(nameof(Name), IsUnique = true)]
public class DataPlan
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int FreeMinutes { get; set; }
}