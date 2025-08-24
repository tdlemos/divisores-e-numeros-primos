using DivisoresEPrimos.Application.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace DivisoresEPrimos.Application.Services;

public class MathService(IMemoryCache memoryCache) : IMathService
{
    private readonly IMemoryCache _memoryCache = memoryCache;

    public List<int> EncontrarDivisores(int n)
    {
        string chaveCache = $"Divisores@{n}";

        if (!_memoryCache.TryGetValue(chaveCache, out List<int> divisors))
        {
            divisors = MathFuncions.EncontrarDivisores(n);

            // Add data to cache
            _memoryCache.Set(chaveCache, divisors);
        }
        return divisors ?? [];
    }

    public List<int> EncontrarPrimos(int n)
    {
        string chaveCache = $"Primos@{n}";

        if (!_memoryCache.TryGetValue(chaveCache, out List<int> primos))
        {
            primos = MathFuncions.EncontrarPrimos(n);

            _memoryCache.Set(chaveCache, primos);
        }
        return primos ?? [];
    }
}
