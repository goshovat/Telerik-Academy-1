using System;

// Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

class CalculateSum
{
    static void Main(string[] args)
    {
        Console.Title = "Calculate sum";

        int n;
        do
        {
            Console.Write("Enter N = ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        Console.Write("Enter X = ");
        int x = int.Parse(Console.ReadLine());

        double sum = 1;
        for (int i = 1; i <= n; i++)
        {
            sum += (double)factorial(i) / Math.Pow(x, i);
        }
        Console.WriteLine("Sum = {0}", sum);
    }

    public static long factorial(int number)
    {
        long numberFactorial = 1;
        for (int i = 2; i <= number; i++)
        {
            numberFactorial *= i;
        }
        return numberFactorial;
    }
}