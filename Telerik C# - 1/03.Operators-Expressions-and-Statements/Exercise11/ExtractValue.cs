using System;

// Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2 -> value=1.

class ExtractValue
{
    static void Main(string[] args)
    {
        int i, b, andValue, bit;
        Console.Write("Enter the number : ");
        i = int.Parse(Console.ReadLine());
        Console.Write("Enter the bit, which value you want to extract : ");
        b = int.Parse(Console.ReadLine());
        andValue = 1 << b;
        i = i & andValue;
        bit = i >> b;
        Console.WriteLine("The extracted bit has value {0} ", bit);
    }
}