using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static VxTel.Tests.VxTelDbContextMock;
using VxTel.Api.Controllers;
using VxTel.Api.Profiles;
using VxTel.Api.Services;

namespace VxTel.Tests;

public class UnitTest1
{
    private readonly TarifaController _controller;

    public UnitTest1()
    {
        var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new TarifaProfile()));
        var mapper = mapperConfiguration.CreateMapper();
        var context = GetDatabaseContext();
        var service = new TarifaService(context, mapper);
        _controller = new TarifaController(service);
    }
    
    [Fact]
    public void Test1()
    {
        var something = _controller.RecuperarTarifas();
        Assert.IsType<OkObjectResult>(something);
    }
}