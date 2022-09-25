using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.City;

public class CreateCityDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int DddCode { get; set; }
}