using System;

/*
    In the combinatorial mathematics, the Catalan numbers are calculated by the following formula: Cn=(2n)!/(n+1)!n! for n>=0
    Write a program to calculate the Nth Catalan number by given N.
 */

class NthCatalanNumber
{
    static void Main(string[] args)
    {
        Console.Title = "N-th Catalan number";

        int catalanNumber = -1;
        double catalanNumberValue;
        while (catalanNumber < 0)
        {
            Console.Write("Enter N = ");
            catalanNumber = int.Parse(Console.ReadLine());
        }
        catalanNumberValue = Factorial(2 * catalanNumber) / (Factorial(catalanNumber + 1) * Factorial(catalanNumber));
        Console.WriteLine("Catalan number[{0}] = {1}", catalanNumber, catalanNumberValue);
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