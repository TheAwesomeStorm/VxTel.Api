using FluentResults;
using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.DataPlan;
using VxTel.Api.Services;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DataPlanController : ControllerBase
{
    private DataPlanService _dataPlanService;
    
    public DataPlanController(DataPlanService service)
    {
        _dataPlanService = service;
    }

    /// <summary>
    ///  Acessa o banco de dados para retornar os planos existentes.
    /// </summary>
    /// <returns>Uma lista referente a um tipo Plano.</returns>
    [HttpGet]
    public IActionResult ReadDataPlans()
    {
        List<ReadDataPlanDto> readDtos = _dataPlanService.GetDataPlans();
        if (readDtos != null) return Ok(readDtos);
        return NoContent();
    }

    /// <summary>
    /// Acessa o banco de dados buscando um Plano específico.
    /// </summary>
    /// <param name="id">O identificador referente ao plano que se deseja visualizar.</param>
    /// <returns>Um Plano se há um Id correspondente no banco de dados, ou um código No Content caso contrário.</returns>
    [HttpGet("{id}")]
    public IActionResult ReadDataPlanById(int id)
    {
        ReadDataPlanDto readDto = _dataPlanService.GetDataPlanById(id);
        if (readDto != null) return Ok(readDto);
        return NoContent();
    }
    
    /// <summary>
    /// Recebe um Plano através do body e o insere no banco de dados.
    /// </summary>
    /// <param name="dataPlanDto">Um objeto Plano, contendo somente os campos que fazem sentido para o método.</param>
    /// <returns>Um status Created se a operação foi concluída com sucesso.</returns>
    [HttpPost]
    public IActionResult CreateDataPlan([FromBody] CreateDataPlanDto dataPlanDto)
    {
        ReadDataPlanDto dataPlan = _dataPlanService.AddDataPlan(dataPlanDto);
        return CreatedAtAction(nameof(ReadDataPlanById), new { dataPlan.Id }, dataPlan);
    }

    /// <summary>
    /// Acessa o banco de dados para remover um Plano específico.
    /// </summary>
    /// <param name="id">O identificador do Plano que se deseja remover.</param>
    /// <returns>Um status Ok se a remoção foi concluída ou um status NoContent caso não exista um Plano com o Id específicado.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteDataPlanById(int id)
    {
        Result result = _dataPlanService.DeleteDataPlanById(id);
        if (result.IsFailed) return NoContent();
        return Ok("Plano removido");
    }
}