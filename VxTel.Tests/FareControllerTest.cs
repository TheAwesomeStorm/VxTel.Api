using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static VxTel.Tests.VxTelDbContextMock;
using VxTel.Api.Controllers;
using VxTel.Api.Data.DTOs.Fare;
using VxTel.Api.Profiles;
using VxTel.Api.Services;

namespace VxTel.Tests;

public class FareControllerTest
{
    private readonly FareController _controller;

    public FareControllerTest()
    {
        var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new FareProfile()));
        var mapper = mapperConfiguration.CreateMapper();
        var context = GetDatabaseContext();
        var service = new FareService(context, mapper);
        _controller = new FareController(service);
    }
    
    [Fact]
    public void ReadFares_WhenCalled_ReturnsOkResult()
    {
        var fares = _controller.ReadFares();
        Assert.IsType<OkObjectResult>(fares);
    }

    [Fact]
    public void ReadFares_WhenCalled_ReturnsAllFares()
    {
        var okResult = _controller.ReadFares() as OkObjectResult;
        var fareDtos = Assert.IsType<List<ReadFareDto>>(okResult.Value);
        Assert.Equal(9, fareDtos.Count);
    }
}