using Microsoft.EntityFrameworkCore;
using VxTel.Api.Data;
using VxTel.Api.Models;

namespace VxTel.Tests;

public static class VxTelDbContextMock
{
    public static VxTelDbContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<VxTelDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        var dbContext = new VxTelDbContext(options);
        dbContext.Database.EnsureCreated();
        for (int i = 1; i <= 10; i++)
        {
            dbContext.Cities.Add(new City()
            {
                Name = $"testCidade{i}",
                DddCode = i,
            });
        }
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                dbContext.Fares.Add(new Fare()
                {
                    OriginCityId = i,
                    DestinationCityId = j,
                    Value = i + j
                });
            }
        }

        dbContext.SaveChanges();
        
        return dbContext;
    }
}