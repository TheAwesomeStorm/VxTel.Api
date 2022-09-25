using AutoMapper;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs.Fare;
using VxTel.Api.Models;

namespace VxTel.Api.Services;

public class FareService
{
    private VxTelDbContext _context;
    private IMapper _mapper;
    
    public FareService(VxTelDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<ReadFareDto> GetFares()
    {
        var fares = _context.Fares.ToList();
        return _mapper.Map<List<ReadFareDto>>(fares);
    }

    public ReadFareDto AddFare(CreateFareDto cidadeDto)
    {
        Fare fare = _mapper.Map<Fare>(cidadeDto);
        _context.Fares.Add(fare);
        _context.SaveChanges();
        return _mapper.Map<ReadFareDto>(fare);
    }

    public ReadFareDto GetFareById(int id)
    {
        var fares = _context.Fares.ToList();
        var fare = fares.FirstOrDefault(tarifa => tarifa.Id == id);
        if (fare != null) return _mapper.Map<ReadFareDto>(fare);
        return null;
    }

    public ReadFareDto GetFareByIdOfDestinationAndOrigin(int destinationCityId, int originCityId)
    {
        var fares = _context.Fares.ToList();
        var fare = fares.FirstOrDefault(tarifa =>
            tarifa.DestinationCityId == destinationCityId && tarifa.OriginCityId == originCityId);
        if (fare == null) return null;
        return _mapper.Map<ReadFareDto>(fare);
    }

    public ReadFareDto GetFareByDddOfDestinationAndOrigin(int destinationCityDdd, int originCityDdd)
    {
        var fares = _context.Fares.ToList();
        var fare = fares.FirstOrDefault(fare =>
            fare.DestinationCity.DddCode == destinationCityDdd
            && fare.OriginCity.DddCode == originCityDdd);
        if (fare == null) return null;
        return _mapper.Map<ReadFareDto>(fare);
    }
}