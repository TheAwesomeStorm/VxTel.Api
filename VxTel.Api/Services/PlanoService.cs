using AutoMapper;
using FluentResults;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs.Plano;
using VxTel.Api.Models;

namespace VxTel.Api.Services;

public class PlanoService
{
    private PlanoContext _context;
    private IMapper _mapper;

    public PlanoService(PlanoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadPlanoDto AdicionarPlano(CreatePlanoDto planoDto)
    {
        Plano plano = _mapper.Map<Plano>(planoDto);
        _context.Planos.Add(plano);
        _context.SaveChanges();
        return _mapper.Map<ReadPlanoDto>(plano);
    }

    public List<ReadPlanoDto> RecuperarPlanos()
    {
        List<Plano> planos = _context.Planos.ToList();
        return _mapper.Map<List<ReadPlanoDto>>(planos);
    }

    public ReadPlanoDto RecuperarPlanoPorId(int id)
    {
        Plano plano = _context.Planos.FirstOrDefault(plano => plano.Id == id);
        if (plano != null)
        {
            return _mapper.Map<ReadPlanoDto>(plano);
        }
        return null;
    }

    public Result RemoverPlanoPorId(int id)
    {
        Plano plano = _context.Planos.FirstOrDefault(plano => plano.Id == id);
        if (plano == null) return Result.Fail("Filme não encontrado");
        _context.Remove(plano);
        _context.SaveChanges();
        return Result.Ok();
    }

}