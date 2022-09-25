using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.CallFare;

public class CallFareByCityIdDto
{
    [Required]
    public int MinutesInCall { get; set; }
    [Required]
    public int OriginCityId { get; set; }
    [Required]
    public int DestinationCityId { get; set; }
}