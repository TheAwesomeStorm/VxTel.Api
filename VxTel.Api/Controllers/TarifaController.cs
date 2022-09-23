using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.Tarifa;
using VxTel.Api.Services;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TarifaController : ControllerBase
{
    private TarifaService _tarifaService;

    public TarifaController(TarifaService tarifaService)
    {
        _tarifaService = tarifaService;
    }
    
    [HttpPost]
    public IActionResult AdicionarTarifa([FromBody] CreateTarifaDto tarifaDto)
    {
        ReadTarifaDto readDto = _tarifaService.AdicionarTarifa(tarifaDto);
        if (readDto != null) return Created("Cidade cadastrada", readDto);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult RecuperarTarifas()
    {
        var tarifaDtos = _tarifaService.RecuperarTarifas();
        if (tarifaDtos != null) return Ok(tarifaDtos);
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarTarifaPorId(int id)
    {
        var tarifaDto = _tarifaService.RecuperarTarifaPorId(id);
        if (tarifaDto != null) return Ok(tarifaDto);
        return NoContent();
    }
}