using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.Fare;
using VxTel.Api.Services;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FareController : ControllerBase
{
    private FareService _fareService;

    public FareController(FareService fareService)
    {
        _fareService = fareService;
    }
    
    [HttpPost]
    public IActionResult CreateFare([FromBody] CreateFareDto fareDto)
    {
        var readDto = _fareService.AddFare(fareDto);
        if (readDto != null)
            return CreatedAtAction(nameof(ReadFareById), new {readDto.Id}, readDto);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult ReadFares()
    {
        var fareDtos = _fareService.GetFares();
        if (fareDtos != null) return Ok(fareDtos);
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult ReadFareById(int id)
    {
        var fareDto = _fareService.GetFareById(id);
        if (fareDto != null) return Ok(fareDto);
        return NoContent();
    }
}