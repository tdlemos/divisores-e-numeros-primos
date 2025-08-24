using DivisoresEPrimos.Application.Contracts;
using DivisoresEPrimos.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DivisoresEPrimos.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncoesMatematicasController(IMathService mathService) : ControllerBase
{
    private readonly IMathService _mathService = mathService;

    [HttpGet("Divisores")]
    public PrimosResponse GetDivisores([FromQuery] int numero)
    {
        var divisores = _mathService.EncontrarDivisores(numero);

        return new PrimosResponse
        {
            Divisores = divisores
        };
    }

    [HttpGet("DivisoresEPrimos")]
    public PrimosEPrimosResponse GetDivisoresEPrimos([FromQuery] int numero)
    {
        var divisores = _mathService.EncontrarDivisores(numero);
        var primos = _mathService.EncontrarPrimos(numero);

        return new PrimosEPrimosResponse  { 
            Divisores = divisores, Primos = primos };
    }
}
