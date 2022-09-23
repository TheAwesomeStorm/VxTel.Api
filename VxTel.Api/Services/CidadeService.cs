﻿using AutoMapper;
using VxTel.Api.Data;
using VxTel.Api.Data.DTOs.Cidade;
using VxTel.Api.Models;

namespace VxTel.Api.Services;

public class CidadeService
{
    private PlanoContext _context;
    private IMapper _mapper;
    
    public CidadeService(PlanoContext context, IMapper mapper)
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
}