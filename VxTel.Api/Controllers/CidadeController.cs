using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.Cidade;
using VxTel.Api.Services;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CidadeController : ControllerBase
{
    private CidadeService _cidadeService;

    public CidadeController(CidadeService cidadeService)
    {
        _cidadeService = cidadeService;
    }

    [HttpPost]
    public IActionResult AdicionarCidade([FromBody] CreateCidadeDto cidadeDto)
    {
        ReadCidadeDto readDto = _cidadeService.AdicionarCidade(cidadeDto);
        if (readDto != null) return Created("Cidade cadastrada", readDto);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult RecuperarCidades()
    {
        var cidadeDtos = _cidadeService.RecuperarCidades();
        if (cidadeDtos != null) return Ok(cidadeDtos);
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarCidadePorId(int id)
    {
        var cidadeDto = _cidadeService.RecuperarCidadePorId(id);
        if (cidadeDto != null) return Ok(cidadeDto);
        return NoContent();
    }
}