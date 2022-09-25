using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.DataPlan;

public class UpdateDataPlanDto
{
    [Required]
    public string Name { get; set; }
    [Required] public int FreeMinutes { get; set; }
}