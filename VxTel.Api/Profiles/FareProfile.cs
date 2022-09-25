using AutoMapper;
using VxTel.Api.Data.DTOs.Fare;
using VxTel.Api.Models;

namespace VxTel.Api.Profiles;

public class FareProfile : Profile
{
    public FareProfile()
    {
        CreateMap<Fare, ReadFareDto>();
        CreateMap<CreateFareDto, Fare>();
    }
}