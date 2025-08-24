namespace DivisoresEPrimos.Application;
public class MathFuncions
{
    public static List<int> EncontrarDivisores(int n)
    {

        List<int> divisors = [];
        int maxDivisor = n / 2;

        // Para ser um divisor, sem que seja ele mesmo,
        // este número deve ser no máximo o valor da metade deste número.
        for (int i = 1; i <= maxDivisor; i++)
        {
            if (n % i == 0)
            {
                divisors.Add(i);
            }
        }

        divisors.Add(n);

        return divisors ?? [];
    }

    public static List<int> EncontrarPrimos(int n)
    {
        List<int> primos = [];

        var lista = EncontrarDivisores(n).ToArray();

        for (int i = 0; i < lista.Length; i++)
        {
            if (EPrimo(lista[i]))
                primos.Add(lista[i]);
        }

        return primos ?? [];
    }

    private static bool EPrimo(int n)
    {
        if (n % 2 == 0)
            return false;

        int maxDivisor = n / 2;

        for (int i = 2; i <= maxDivisor; i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }
}
