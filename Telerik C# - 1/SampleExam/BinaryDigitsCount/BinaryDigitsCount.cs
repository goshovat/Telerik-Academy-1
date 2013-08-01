using System;
using System.Numerics;

class BinaryDigitsCount
{
    static void Main(string[] args)
    {
        char bit = char.Parse(Console.ReadLine());

        int n = int.Parse(Console.ReadLine());

        long num;

        string[] numbers = new string[n];

        for (int i = 0; i < n; i++)
        {
            num = long.Parse(Console.ReadLine());
            numbers[i] = Convert.ToString(num, 2);
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(CountBits(numbers[i], bit));
        }
    
    }

    static int CountBits(string numberBits, char value)
    {
        int countBits = 0;
        for (int i = 0; i < numberBits.Length; i++)
        {
            if (numberBits[i].Equals(value))
            {
                countBits++;
            }
        }

        return countBits;
    }
}