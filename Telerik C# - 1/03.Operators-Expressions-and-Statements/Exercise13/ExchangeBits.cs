using System;

// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

class ExchangeBits
{
    static void Main(string[] args)
    {
        uint number;
        int[] bit = new int[6];
        int i, j;
        Console.Write("Enter the number : ");
        number = uint.Parse(Console.ReadLine());
        // Extract bits, which possition is 3, 4, 5, 24, 25, 26 and save their values in the array "bit".
        for (i = 0, j = 3; i < 6; i++, j++)
        {
            if (j == 6)
            {
                j = 24;
            }
            bit[i] = 1 << j;
            bit[i] = bit[i] & (int)number;
            bit[i] = bit[i] >> j;
            Console.WriteLine("Bit {0} = {1}", j, bit[i]);
        }
        // Taking the values from the array and assing it to the bit  24, 25, 26, 2, 3, 4.
        for (i = 0, j = 24; i < 6; i++, j++)
        {
            if (j == 27)
            {
                j = 3;
            }
            if (bit[i] == 0)
            {
                bit[i] = 1;
                bit[i] = ~(bit[i] << j);
                number = number & (uint)bit[i];
            }
            else
            {
                bit[i] = bit[i] << j;
                number = number | (uint)bit[i];
            }
        }
        // Printing the new number and the changed bits.
        Console.WriteLine("The new number is {0}.", number);
        for (i = 0, j = 3; i < 6; i++, j++)
        {
            if (j == 6)
            {
                j = 24;
            }
            bit[i] = 1 << j;
            bit[i] = bit[i] & (int)number;
            bit[i] = bit[i] >> j;
            Console.WriteLine("The new value of bit {0} = {1}", j, bit[i]);
        }
    }
}