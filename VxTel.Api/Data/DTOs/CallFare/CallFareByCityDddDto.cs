using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.CallFare;

public class CallFareByCityDddDto
{
    [Required]
    public int MinutesInCall { get; set; }
    [Required]
    public int OriginCityDdd { get; set; }
    [Required]
    public int DestinationCityDdd { get; set; }
}