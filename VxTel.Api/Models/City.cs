using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace VxTel.Api.Models;

[Index(nameof(DddCode), IsUnique = true)]
public class City
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int DddCode { get; set; }
    [JsonIgnore]
    public virtual List<Fare> FaresAsOrigin { get; set; }
    [JsonIgnore]
    public virtual List<Fare> FaresAsDestination { get; set; }
}