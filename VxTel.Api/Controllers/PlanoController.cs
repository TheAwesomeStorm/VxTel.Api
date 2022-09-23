using FluentResults;
using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs;
using VxTel.Api.Services;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlanoController : ControllerBase
{
    private PlanoService _planoService;
    
    public PlanoController(PlanoService service)
    {
        _planoService = service;
    }

    /// <summary>
    ///  Acessa o banco de dados para retornar os planos existentes.
    /// </summary>
    /// <returns>Uma lista referente a um tipo Plano.</returns>
    [HttpGet]
    public IActionResult RecuperarPlanos()
    {
        List<ReadPlanoDto> readDtos = _planoService.RecuperarPlanos();
        if (readDtos != null) return Ok(readDtos);
        return NoContent();
    }

    /// <summary>
    /// Acessa o banco de dados buscando um Plano específico.
    /// </summary>
    /// <param name="id">O identificador referente ao plano que se deseja visualizar.</param>
    /// <returns>Um Plano se há um Id correspondente no banco de dados, ou um código No Content caso contrário.</returns>
    [HttpGet("{id}")]
    public IActionResult RecuperarPlanoPorId(int id)
    {
        ReadPlanoDto readDto = _planoService.RecuperarPlanoPorId(id);
        if (readDto != null) return Ok(readDto);
        return NoContent();
    }
    
    /// <summary>
    /// Recebe um Plano através do body e o insere no banco de dados.
    /// </summary>
    /// <param name="planoDto">Um objeto Plano, contendo somente os campos que fazem sentido para o método.</param>
    /// <returns>Um status Created se a operação foi concluída com sucesso.</returns>
    [HttpPost]
    public IActionResult AdicionarPlano([FromBody] CreatePlanoDto planoDto)
    {
        ReadPlanoDto plano = _planoService.AdicionarPlano(planoDto);
        return CreatedAtAction(nameof(RecuperarPlanoPorId), new { plano.Id }, plano);
    }

    /// <summary>
    /// Acessa o banco de dados para remover um Plano específico.
    /// </summary>
    /// <param name="id">O identificador do Plano que se deseja remover.</param>
    /// <returns>Um status Ok se a remoção foi concluída ou um status NoContent caso não exista um Plano com o Id específicado.</returns>
    [HttpDelete("{id}")]
    public IActionResult RemoverPlanoPorId(int id)
    {
        Result result = _planoService.RemoverPlanoPorId(id);
        if (result.IsFailed) return NoContent();
        return Ok("Plano removido");
    }
}