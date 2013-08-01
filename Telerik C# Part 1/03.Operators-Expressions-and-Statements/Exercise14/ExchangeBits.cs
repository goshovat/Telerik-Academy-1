using System;

// Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

class ExchangeBits
{
    static void Main(string[] args)
    {
        uint number;
        int[] bit;
        int i, j, startPointSequence1, startPointSequence2, sequenceLenght;
        Console.Write("Enter the number : ");
        number = uint.Parse(Console.ReadLine());
        Console.Write("Enter the bit from which you want to start the first sequence : ");
        startPointSequence1 = int.Parse(Console.ReadLine());
        Console.Write("Enter the lenght of the sequence : ");
        sequenceLenght = int.Parse(Console.ReadLine());
        bit = new int[sequenceLenght * 2];
        Console.Write("Enter the bit from which you want to start the second sequence : ");
        startPointSequence2 = int.Parse(Console.ReadLine());
        // Extract bits  and save their value in the array "bit".
        for (i = 0, j = startPointSequence1; i < sequenceLenght * 2; i++, j++)
        {
            if (j == startPointSequence1 + sequenceLenght)
            {
                j = startPointSequence2;
            }
            bit[i] = 1 << j;
            bit[i] = bit[i] & (int)number;
            bit[i] = bit[i] >> j;
            Console.WriteLine("Bit {0} = {1}", j, bit[i]);
        }
        // Taking the values from the array and assing it to the bits
        for (i = 0, j = startPointSequence2; i < sequenceLenght * 2; i++, j++)
        {
            if (j == startPointSequence2 + sequenceLenght)
            {
                j = startPointSequence1;
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
        Console.WriteLine("\nThe new number is {0}.", number);
        for (i = 0, j = startPointSequence1; i < sequenceLenght * 2; i++, j++)
        {
            if (j == startPointSequence1 + sequenceLenght)
            {
                j = startPointSequence2;
            }
            bit[i] = 1 << j;
            bit[i] = bit[i] & (int)number;
            bit[i] = bit[i] >> j;
            Console.WriteLine("The new value of bit {0} = {1}", j, bit[i]);
        }
    }
}