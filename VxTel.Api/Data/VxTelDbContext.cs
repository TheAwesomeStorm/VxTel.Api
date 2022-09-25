using Microsoft.EntityFrameworkCore;
using VxTel.Api.Models;

namespace VxTel.Api.Data;

public class VxTelDbContext : DbContext
{
    public VxTelDbContext(DbContextOptions<VxTelDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Fare>()
            .HasOne(fare => fare.DestinationCity)
            .WithMany(city => city.FaresAsDestination)
            .HasForeignKey(fare => fare.DestinationCityId);

        builder.Entity<Fare>()
            .HasOne(fare => fare.OriginCity)
            .WithMany(city => city.FaresAsOrigin)
            .HasForeignKey(fare => fare.OriginCityId);
    }
    
    public DbSet<DataPlan> DataPlans { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Fare> Fares { get; set; }
}