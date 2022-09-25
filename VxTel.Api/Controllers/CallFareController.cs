using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.CallFare;
using VxTel.Api.Services;
using VxTel.Api.Usecases;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("chamada")]
public class CallFareController : ControllerBase
{
    private FareService _fareService;
    private CallFareUsecase _callFareUsecase;
    private DataPlanService _dataPlanService;
    
    public CallFareController(FareService fareService, DataPlanService dataPlanService, CallFareUsecase callFareUsecase)
    {
        _fareService = fareService;
        _dataPlanService = dataPlanService;
        _callFareUsecase = callFareUsecase;
    }
    
    [HttpGet]
    [Route("idCidade")]
    public IActionResult ReadCallFareByCityId([FromQuery] CallFareByCityIdDto callFareByCityIdDto)
    {
        var fareDto = _fareService.GetFareByIdOfDestinationAndOrigin(callFareByCityIdDto.DestinationCityId,
            callFareByCityIdDto.OriginCityId);
        var callFare = _callFareUsecase.CalculateCallFare(callFareByCityIdDto.MinutesInCall, fareDto.Value);
        return Ok(callFare);
    }

    [HttpGet]
    [Route("ddd")]
    public IActionResult ReadCallFareByDdd([FromQuery] CallFareByCityDddDto callFareByCityDddDto)
    {
        var fareDto =
            _fareService.GetFareByDddOfDestinationAndOrigin(callFareByCityDddDto.DestinationCityDdd,
                callFareByCityDddDto.OriginCityDdd);
        var callFare = _callFareUsecase.CalculateCallFare(callFareByCityDddDto.MinutesInCall, fareDto.Value);
        return Ok(callFare);
    }

    [HttpGet]
    public IActionResult ReadCallFareWithDataPlanByDdd([FromQuery] CallFareByCityDddDto callFareByCityDddDto,
        [FromQuery][Required] int idPlano)
    {
        var dataPlanDto = _dataPlanService.GetDataPlanById(idPlano);
        var fareDto = _fareService.GetFareByDddOfDestinationAndOrigin(callFareByCityDddDto.DestinationCityDdd,
            callFareByCityDddDto.OriginCityDdd);
        var callFare =
            _callFareUsecase.CalculateCallFareWithDataPlan(callFareByCityDddDto.MinutesInCall, fareDto.Value, dataPlanDto);
        return Ok(callFare);
    }
}