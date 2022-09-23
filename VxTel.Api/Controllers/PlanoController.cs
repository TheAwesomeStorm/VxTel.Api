using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs;
using VxTel.Api.Models;
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

    [HttpGet]
    public IActionResult RecuperarPlanos()
    {
        List<ReadPlanoDto> readDtos = _planoService.RecuperarPlanos();
        if (readDtos != null) return Ok(readDtos);
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarPlanoPorId(int id)
    {
        ReadPlanoDto readDto = _planoService.RecuperarPlanoPorId(id);
        if (readDto != null) return Ok(readDto);
        return NoContent();
    }
    
    [HttpPost]
    public IActionResult AdicionarPlano([FromBody] CreatePlanoDto planoDto)
    {
        ReadPlanoDto plano = _planoService.AdicionarPlano(planoDto);
        return CreatedAtAction(nameof(RecuperarPlanoPorId), new {Id = plano.Id}, plano);
    }
}