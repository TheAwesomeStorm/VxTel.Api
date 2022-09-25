using VxTel.Api.Data.DTOs.DataPlan;

namespace VxTel.Api.Usecases;

public class CallFareUsecase
{
    public float CalculateCallFare(int duracaoMinutos, float valorTarifa)
    {
        return duracaoMinutos * valorTarifa;
    }

    public float CalculateCallFareWithDataPlan(int duracaoMinutos, float valorTarifa, ReadDataPlanDto dataPlanDto)
    {
        var minutosExcedentes = duracaoMinutos - dataPlanDto.FreeMinutes;
        if (minutosExcedentes <= 0) return 0;
        return minutosExcedentes * 1.1f * valorTarifa;
    }
}