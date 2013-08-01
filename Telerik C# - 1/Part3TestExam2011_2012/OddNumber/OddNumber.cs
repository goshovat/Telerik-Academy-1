using System;
using System.Numerics;

class OddNumber
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger number = 0;

        for (int i = 0; i < n; i++)
        {
            number ^= BigInteger.Parse(Console.ReadLine()); 
        }
        Console.WriteLine(number);
    
    }
}