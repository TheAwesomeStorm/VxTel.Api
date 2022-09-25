using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Data.DTOs.DataPlan;

public class CreateDataPlanDto
{
    [Required]
    public string Name { get; set; }
    [Required] public int FreeMinutes { get; set; }
}