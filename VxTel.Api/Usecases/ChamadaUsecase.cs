using VxTel.Api.Data.DTOs.Chamada;
using VxTel.Api.Services;

namespace VxTel.Api.Usecases;

public class ChamadaUsecase
{
    private TarifaService _tarifaService;
    
    public ChamadaUsecase(TarifaService tarifaService)
    {
        _tarifaService = tarifaService;
    }
    
    public float ObterCustoChamada(ChamadaDto chamadaDto)
    {
        var tarifa = _tarifaService
            .RecuperarTarifaPorDestinoEOrigem(chamadaDto.IdCidadeDestino, chamadaDto.IdCidadeOrigem);
        return chamadaDto.DuracaoMinutos * tarifa.valor;
    }
}