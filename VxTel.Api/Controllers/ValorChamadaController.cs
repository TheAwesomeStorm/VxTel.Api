using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Data.DTOs.Chamada;
using VxTel.Api.Services;
using VxTel.Api.Usecases;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("chamada")]
public class ValorChamadaController : ControllerBase
{
    private TarifaService _tarifaService;
    private ValorChamadaUsecase _valorChamadaUsecase;
    
    public ValorChamadaController(TarifaService tarifaService, ValorChamadaUsecase valorChamadaUsecase)
    {
        _tarifaService = tarifaService;
        _valorChamadaUsecase = valorChamadaUsecase;
    }
    
    [HttpGet]
    [Route("idCidade")]
    public IActionResult ObterValorChamadaPorId([FromQuery] ValorChamadaIdDto valorChamadaIdDto)
    {
        var tarifa = _tarifaService.RecuperarTarifaPorIdDestinoEOrigem(valorChamadaIdDto.IdCidadeDestino,
            valorChamadaIdDto.IdCidadeOrigem);
        var valorChamada = _valorChamadaUsecase.ObterCustoChamada(valorChamadaIdDto.DuracaoMinutos, tarifa.valor);
        return Ok(valorChamada);
    }

    [HttpGet]
    [Route("ddd")]
    public IActionResult ObterValorChamadaPorDdd([FromQuery] ValorChamadaDddDto valorChamadaDddDto)
    {
        var tarifa =
            _tarifaService.RecuperarTarifaPorDddDestinoEOrigem(valorChamadaDddDto.DddCidadeDestino,
                valorChamadaDddDto.DddCidadeOrigem);
        var valorChamada = _valorChamadaUsecase.ObterCustoChamada(valorChamadaDddDto.DuracaoMinutos, tarifa.valor);
        return Ok(valorChamada);
    }
}