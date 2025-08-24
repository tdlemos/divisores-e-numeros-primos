namespace DivisoresEPrimos.Application.Contracts;

public interface IMathService
{
    List<int> EncontrarDivisores(int n);
    List<int> EncontrarPrimos(int n);
}