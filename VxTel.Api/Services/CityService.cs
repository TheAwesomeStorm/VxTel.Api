using AutoMapper;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs.City;
using VxTel.Api.Models;

namespace VxTel.Api.Services;

public class CityService
{
    private VxTelDbContext _context;
    private IMapper _mapper;
    
    public CityService(VxTelDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadCityDto AddCity(CreateCityDto cityDto)
    {
        City city = _mapper.Map<City>(cityDto);
        _context.Cities.Add(city);
        _context.SaveChanges();
        return _mapper.Map<ReadCityDto>(city);
    }

    public List<ReadCityDto> GetCities()
    {
        var cities = _context.Cities.ToList();
        return _mapper.Map<List<ReadCityDto>>(cities);
    }

    public ReadCityDto GetCityById(int id)
    {
        var cities = _context.Cities.ToList();
        var city = cities.FirstOrDefault(city => city.Id == id);
        if (city != null) return _mapper.Map<ReadCityDto>(city);
        return null;
    }
}