using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.Fare;

public class CreateFareDto
{
    [Required]
    public int OriginCityId { get; set; }
    [Required]
    public int DestinationCityId { get; set; }
    [Required]
    public float Value { get; set; }
}