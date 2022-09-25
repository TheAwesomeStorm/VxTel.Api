using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Fare;

public class ReadFareDto
{
    [Key][Required]
    public int Id { get; internal set; }
    [Required]
    public Models.City OriginCity { get; set; }
    [Required]
    public Models.City DestinationCity { get; set; }
    [Required]
    public float Value { get; set; }
}