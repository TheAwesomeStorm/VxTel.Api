using AutoMapper;
using VxTel.Api.Data.DTOs.Tarifa;
using VxTel.Api.Models;

namespace VxTel.Api.Profiles;

public class TarifaProfile : Profile
{
    public TarifaProfile()
    {
        CreateMap<Tarifa, ReadTarifaDto>();
        CreateMap<CreateTarifaDto, Tarifa>();
    }
}