using AutoMapper;
using VxTel.Api.Data.DTOs.Cidade;
using VxTel.Api.Models;

namespace VxTel.Api.Profiles;

public class CidadeProfile : Profile
{
    public CidadeProfile()
    {
        CreateMap<Cidade, ReadCidadeDto>();
        CreateMap<CreateCidadeDto, Cidade>();
    }
}