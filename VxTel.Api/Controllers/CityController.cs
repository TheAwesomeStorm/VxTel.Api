using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.City;
using VxTel.Api.Services;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private CityService _cityService;

    public CityController(CityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost]
    public IActionResult CreateCity([FromBody] CreateCityDto cityDto)
    {
        ReadCityDto readDto = _cityService.AddCity(cityDto);
        if (readDto != null) return Created("Cidade cadastrada", readDto);
        return BadRequest();
    }

    [HttpGet]
    public IActionResult ReadCities()
    {
        var cityDtos = _cityService.GetCities();
        if (cityDtos != null) return Ok(cityDtos);
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult ReadCityById(int id)
    {
        var cityDto = _cityService.GetCityById(id);
        if (cityDto != null) return Ok(cityDto);
        return NoContent();
    }
}