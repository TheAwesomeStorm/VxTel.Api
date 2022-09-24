using VxTel.Api.Data.DTOs.Chamada;
using VxTel.Api.Services;

namespace VxTel.Api.Usecases;

public class ValorChamadaUsecase
{
    public float ObterCustoChamada(int duracaoMinutos, float valorTarifa)
    {
        return duracaoMinutos * valorTarifa;
    }
}