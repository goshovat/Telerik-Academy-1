using System;

// Write a program that calculates N!/K! for given N and K (1<K<N).


class CalulateExpression
{
    static void Main(string[] args)
    {
        Console.Title = "Calculate expression";
        int n, k;
        do
        {
            Console.Write("Enter N = ");
            n = int.Parse(Console.ReadLine());
        } while (n < 2);

        do
        {
            Console.Write("Enter K = ");
            k = int.Parse(Console.ReadLine());
        } while (k < 2 || k >= n);

        long result = 1;
        for (int i = n; i > k; i--)
        {
            result *= i;
        }
        Console.WriteLine("N! / K! = {0}", result);
    }
}