using System;

/*
    We are given integer number n, value v (v=0 or 1) and a position p. 
    Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
    Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
    n = 5 (00000101), p=2, v=0 -> 1 (00000001)
*/

class SetValue
{
    static void Main(string[] args)
    {
        int i, b, orValue, andValue;
        sbyte v = 2;
        Console.Write("Enter the number : ");
        i = int.Parse(Console.ReadLine());
        Console.Write("Enter the bit, which value you want to set : ");
        b = int.Parse(Console.ReadLine());
        while (v < 0 || v > 1)
        {
            Console.Write("Enter the value (0 or 1) : ");
            v = sbyte.Parse(Console.ReadLine());

        }
        if (v == 1)
        {
            orValue = 1 << b;
            i = i | orValue;
        }

        else
        {
            andValue = ~(1 << b);
            i = i & andValue;
        }
        Console.WriteLine("The new number is {0}.", i);
    }
}