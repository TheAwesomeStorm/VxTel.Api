using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.DataPlan;

public class ReadDataPlanDto
{
    [Key][Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required] public int FreeMinutes { get; set; }
}