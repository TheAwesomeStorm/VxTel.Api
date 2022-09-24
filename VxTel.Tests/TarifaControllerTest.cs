using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static VxTel.Tests.VxTelDbContextMock;
using VxTel.Api.Controllers;
using VxTel.Api.Data.DTOs.Tarifa;
using VxTel.Api.Profiles;
using VxTel.Api.Services;

namespace VxTel.Tests;

public class TarifaControllerTest
{
    private readonly TarifaController _controller;

    public TarifaControllerTest()
    {
        var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new TarifaProfile()));
        var mapper = mapperConfiguration.CreateMapper();
        var context = GetDatabaseContext();
        var service = new TarifaService(context, mapper);
        _controller = new TarifaController(service);
    }
    
    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
    {
        var tarifas = _controller.RecuperarTarifas();
        Assert.IsType<OkObjectResult>(tarifas);
    }

    [Fact]
    public void RecuperarTarifas_WhenCalled_ReturnsAllTarifas()
    {
        var okResult = _controller.RecuperarTarifas() as OkObjectResult;
        var tarifas = Assert.IsType<List<ReadTarifaDto>>(okResult.Value);
        Assert.Equal(9, tarifas.Count);
    }
}