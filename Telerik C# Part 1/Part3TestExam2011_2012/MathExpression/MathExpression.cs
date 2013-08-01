using System;

class MathExpression
{
    static void Main(string[] args)
    {
        double n = double.Parse(Console.ReadLine());

        double m = double.Parse(Console.ReadLine());

        double p = double.Parse(Console.ReadLine());

        double chislitel = n * n + 1 / (m * p) + 1337;

        double znamenatel = n - 128.523123123 * p;

        double product = chislitel / znamenatel + Math.Sin((int)m % 180);
        Console.WriteLine("{0:F6}", product);
    }
}