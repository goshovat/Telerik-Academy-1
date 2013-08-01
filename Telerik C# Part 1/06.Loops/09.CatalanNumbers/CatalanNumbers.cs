using System;

// In the combinatorial mathematics, the Catalan numbers are calculated by the following formula: Cn=(2n)!/(n+1)!n! for n>=0

class CatalanNumbers
{
    static void Main(string[] args)
    {
        Console.Title = "Catalan numbers";

        int catalanNumber = -1;
        double catalanNumberValue;
        while (catalanNumber < 0)
        {
            Console.Write("Enter n = ");
            catalanNumber = int.Parse(Console.ReadLine());
        }
        for (int i = 1; i <= catalanNumber; i++)
        {
            catalanNumberValue = Factorial(2 * i) / (Factorial(i + 1) * Factorial(i));
            Console.WriteLine("Catalan number[{0}] = {1}", i, catalanNumberValue);
        }

    }

    static double Factorial(int x)
    {
        double factorialProduct = 1;
        for (int i = 2; i <= x; i++)
        {
            factorialProduct *= i;
        }
        return factorialProduct;
    }
}