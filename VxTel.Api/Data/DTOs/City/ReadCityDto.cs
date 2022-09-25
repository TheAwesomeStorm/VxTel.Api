using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.City;

public class ReadCityDto
{
    [Key][Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int DddCode { get; set; }
    public object FaresAsOrigin { get; set; }
    public object FaresAsDestination { get; set; }
}