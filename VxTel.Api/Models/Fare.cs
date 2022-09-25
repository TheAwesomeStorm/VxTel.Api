using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace VxTel.Api.Models;

[Index(nameof(OriginCityId), nameof(DestinationCityId), IsUnique = true)]
public class Fare
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public int OriginCityId { get; set; }
    [Required]
    public int DestinationCityId { get; set; }
    [Required]
    public float Value { get; set; }
    [JsonIgnore]
    public virtual City OriginCity { get; set; }
    [JsonIgnore]
    public virtual City DestinationCity { get; set; }
}