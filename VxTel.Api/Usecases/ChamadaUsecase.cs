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
    
    public float ObterCustoChamadaPorIdCidade(ChamadaIdDto chamadaIdDto)
    {
        var tarifa = _tarifaService
            .RecuperarTarifaPorDestinoEOrigem(chamadaIdDto.IdCidadeDestino, chamadaIdDto.IdCidadeOrigem);
        return chamadaIdDto.DuracaoMinutos * tarifa.valor;
    }

    public float ObterCustoChamadaPorDddCidade(ChamadaDddDto chamadaDddDto)
    {
        var tarifa = _tarifaService
            .RecuperarTarifaPorDddDestinoEOrigem(chamadaDddDto.DddCidadeDestino, chamadaDddDto.DddCidadeOrigem);
        return chamadaDddDto.DuracaoMinutos * tarifa.valor;
    }
}