using Microsoft.AspNetCore.Mvc;
using VxTel.Api.Models;

namespace VxTel.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlanoController : ControllerBase
{
    private static List<Plano> _planos = new List<Plano>();

    [HttpPost]
    public void AdicionarPlano([FromBody]Plano plano)
    {
        _planos.Add(plano);
        Console.WriteLine(plano.Nome);
    }
}