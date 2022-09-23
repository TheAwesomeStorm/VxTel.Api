using AutoMapper;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs.Cidade;
using VxTel.Api.Models;

namespace VxTel.Api.Services;

public class CidadeService
{
    private VxTelDbContext _context;
    private IMapper _mapper;
    
    public CidadeService(VxTelDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadCidadeDto AdicionarCidade(CreateCidadeDto cidadeDto)
    {
        Cidade cidade = _mapper.Map<Cidade>(cidadeDto);
        _context.Cidades.Add(cidade);
        _context.SaveChanges();
        return _mapper.Map<ReadCidadeDto>(cidade);
    }

    public List<ReadCidadeDto> RecuperarCidades()
    {
        var cidades = _context.Cidades.ToList();
        return _mapper.Map<List<ReadCidadeDto>>(cidades);
    }

    public ReadCidadeDto RecuperarCidadePorId(int id)
    {
        var cidades = _context.Cidades.ToList();
        var cidade = cidades.FirstOrDefault(cidade => cidade.Id == id);
        if (cidade != null) return _mapper.Map<ReadCidadeDto>(cidade);
        return null;
    }
}