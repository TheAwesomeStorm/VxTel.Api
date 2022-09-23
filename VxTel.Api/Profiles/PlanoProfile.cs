using AutoMapper;
using VxTel.Api.Data.DTOs.Plano;
using VxTel.Api.Models;

namespace VxTel.Api.Profiles;

public class PlanoProfile : Profile
{
    public PlanoProfile()
    {
        CreateMap<Plano, ReadPlanoDto>();
        CreateMap<CreatePlanoDto, Plano>();
        CreateMap<UpdatePlanoDto, Plano>();
    }
}