using Microsoft.EntityFrameworkCore;
using VxTel.Api.Models;

namespace VxTel.Api.Data;

public class PlanoContext : DbContext
{
    public PlanoContext(DbContextOptions<PlanoContext> options) : base(options) {}
    
    public DbSet<Plano> Planos { get; set; }
}