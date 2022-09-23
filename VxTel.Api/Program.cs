using Microsoft.EntityFrameworkCore;
using VxTel.Api.Data;
using VxTel.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

// XML comments for Swagger
var xmlFilename = $"{Directory.GetCurrentDirectory()}/obj/debug/net6.0/VxTel.Api.xml";
services.AddSwaggerGen(options => options.IncludeXmlComments(xmlFilename));

// Add DbContext to services

services.AddDbContext<PlanoContext>(options => options
    .UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(5, 7))));
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<PlanoService, PlanoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();