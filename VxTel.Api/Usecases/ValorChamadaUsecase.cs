using VxTel.Api.Data.DTOs.Plano;

namespace VxTel.Api.Usecases;

public class ValorChamadaUsecase
{
    public float ObterCustoChamada(int duracaoMinutos, float valorTarifa)
    {
        return duracaoMinutos * valorTarifa;
    }

    public float ObterCustoChamadaComPlano(int duracaoMinutos, float valorTarifa, ReadPlanoDto planoDto)
    {
        var minutosExcedentes = duracaoMinutos - planoDto.Minutos;
        if (minutosExcedentes <= 0) return 0;
        return minutosExcedentes * 1.1f * valorTarifa;
    }
}