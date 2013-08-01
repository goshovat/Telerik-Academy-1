using System;

/*
    Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v
    has value of 1. Example: v=5; p=1 -> false.
*/

class CheckBitP
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number : ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter the bit, which value you want to check : ");
        int p = int.Parse(Console.ReadLine());
        int andMask = 1 << p;
        bool bitValue = (v & andMask) != 0;
        Console.WriteLine( bitValue ? "The bit at position {0} has value 1!" : "The bit at position {0} has value 0!", p);
    }
}