using DivisoresEPrimos.Application;

Console.WriteLine("Entre com o número para encontrar seus divisores: ");
string numero = Console.ReadLine();

int numeroASerProcurado = int.Parse(numero);


var divisores = MathFuncions.EncontrarDivisores(numeroASerProcurado);
var primos = MathFuncions.EncontrarPrimos(numeroASerProcurado);

Console.WriteLine($"Números de entrada: {numeroASerProcurado}");
Console.WriteLine($"Números divisores: {string.Join(", ", divisores)}");
Console.WriteLine($"Divisores Primos: {string.Join(", ", primos)}");