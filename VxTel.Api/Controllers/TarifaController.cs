using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.Chamada;
using VxTel.Api.Data.DTOs.Tarifa;
using VxTel.Api.Services;
using VxTel.Api.Usecases;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TarifaController : ControllerBase
{
    private TarifaService _tarifaService;
    private ChamadaUsecase _chamadaUsecase;

    public TarifaController(TarifaService tarifaService, ChamadaUsecase chamadaUsecase)
    {
        _tarifaService = tarifaService;
        _chamadaUsecase = chamadaUsecase;
    }
    
    [HttpPost]
    public IActionResult AdicionarTarifa([FromBody] CreateTarifaDto tarifaDto)
    {
        var readDto = _tarifaService.AdicionarTarifa(tarifaDto);
        if (readDto != null)
            return CreatedAtAction(nameof(RecuperarTarifaPorId), new {readDto.Id}, readDto);
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

    [HttpGet]
    [Route("chamada")]
    public IActionResult ObterValorChamada([FromQuery] ChamadaDto chamadaDto)
    {
        float valorTarifa = _chamadaUsecase.ObterCustoChamada(chamadaDto);
        return Ok(valorTarifa);
    }
}