using System;

// Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

class CalculateExpression
{
    static void Main(string[] args)
    {
        Console.Title = "Calculate expression";
        int n, k;
        do
        {
            Console.Write("Enter K = ");
            k = int.Parse(Console.ReadLine());
        } while (k < 2);

        do
        {
            Console.Write("Enter N = ");
            n = int.Parse(Console.ReadLine());
        } while (n < 2 || n >= k);

        long result = 1;
        for (int i = k; i > k - n; i--) // calculate K! / (K-N)!
        {
            result *= i;
        }

        for (int i = 2; i <= n; i++) // calculate N! * result from the previous loop
        {
            result *= i;
        }
        Console.WriteLine("N!*K! / (K-N)! = {0}", result);
    }
}