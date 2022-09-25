using AutoMapper;
using VxTel.Api.Data.DTOs.City;
using VxTel.Api.Models;

namespace VxTel.Api.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, ReadCityDto>();
        CreateMap<CreateCityDto, City>();
    }
}