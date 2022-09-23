using Microsoft.EntityFrameworkCore;
using VxTel.Api.Models;

namespace VxTel.Api.Data;

public class PlanoContext : DbContext
{
    public PlanoContext(DbContextOptions<PlanoContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Tarifa>()
            .HasOne(tarifa => tarifa.CidadeDestino)
            .WithMany(cidade => cidade.TarifasComoDestino)
            .HasForeignKey(tarifa => tarifa.IdCidadeDestino);

        builder.Entity<Tarifa>()
            .HasOne(tarifa => tarifa.CidadeOrigem)
            .WithMany(cidade => cidade.TarifasComoOrigem)
            .HasForeignKey(tarifa => tarifa.IdCidadeOrigem);
    }
    
    public DbSet<Plano> Planos { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Tarifa> Tarifas { get; set; }
}