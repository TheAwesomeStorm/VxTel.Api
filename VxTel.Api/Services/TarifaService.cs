using AutoMapper;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs.Tarifa;
using VxTel.Api.Models;

namespace VxTel.Api.Services;

public class TarifaService
{
    private VxTelDbContext _context;
    private IMapper _mapper;
    
    public TarifaService(VxTelDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<ReadTarifaDto> RecuperarTarifas()
    {
        var tarifas = _context.Tarifas.ToList();
        return _mapper.Map<List<ReadTarifaDto>>(tarifas);
    }

    public ReadTarifaDto AdicionarTarifa(CreateTarifaDto cidadeDto)
    {
        Tarifa tarifa = _mapper.Map<Tarifa>(cidadeDto);
        _context.Tarifas.Add(tarifa);
        _context.SaveChanges();
        return _mapper.Map<ReadTarifaDto>(tarifa);
    }

    public ReadTarifaDto RecuperarTarifaPorId(int id)
    {
        var tarifas = _context.Tarifas.ToList();
        var tarifa = tarifas.FirstOrDefault(tarifa => tarifa.Id == id);
        if (tarifa != null) return _mapper.Map<ReadTarifaDto>(tarifa);
        return null;
    }

    public ReadTarifaDto RecuperarTarifaPorDestinoEOrigem(int idCidadeDestino, int idCidadeOrigem)
    {
        var tarifas = _context.Tarifas.ToList();
        var tarifa = tarifas.FirstOrDefault(tarifa =>
            tarifa.IdCidadeDestino == idCidadeDestino && tarifa.IdCidadeOrigem == idCidadeOrigem);
        if (tarifa == null) return null;
        return _mapper.Map<ReadTarifaDto>(tarifa);
    }

    public ReadTarifaDto RecuperarTarifaPorDddDestinoEOrigem(int dddCidadeDestino, int dddCidadeOrigem)
    {
        var tarifas = _context.Tarifas.ToList();
        var tarifa = tarifas.FirstOrDefault(tarifa =>
            tarifa.CidadeDestino.CodigoDdd == dddCidadeDestino
            && tarifa.CidadeOrigem.CodigoDdd == dddCidadeOrigem);
        if (tarifa == null) return null;
        return _mapper.Map<ReadTarifaDto>(tarifa);
    }
}