using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static VxTel.Tests.VxTelDbContextMock;
using VxTel.Api.Controllers;
using VxTel.Api.Data;
using VxTel.Api.Profiles;
using VxTel.Api.Services;
using VxTel.Api.Usecases;

namespace VxTel.Tests;

public class UnitTest1
{
    private readonly TarifaController _controller;
    private readonly TarifaService _service;
    private readonly VxTelDbContext _context;
    private readonly ChamadaUsecase _usecase;
    private readonly IMapper _mapper;

    public UnitTest1()
    {
        var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new TarifaProfile()));
        _mapper = mapperConfiguration.CreateMapper();
        _context = GetDatabaseContext();
        _service = new TarifaService(_context, _mapper);
        _usecase = new ChamadaUsecase(_service);
        _controller = new TarifaController(_service, _usecase);
    }
    
    [Fact]
    public void Test1()
    {
        var something = _controller.RecuperarTarifas();
        Assert.IsType<OkObjectResult>(something);
    }
}