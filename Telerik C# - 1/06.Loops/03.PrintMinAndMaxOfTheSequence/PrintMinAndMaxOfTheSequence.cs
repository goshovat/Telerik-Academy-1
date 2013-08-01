using System;

// Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

class PrintMinAndMaxOfTheSequence
{
    static void Main(string[] args)
    {
        Console.Title = "Print min and max value of the sequence";
        Console.Write("How many numbers you want to have a sequence : ");
        int size = int.Parse(Console.ReadLine());
        int[] sequence = new int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write("number[{0}] = ", i + 1);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        int max = sequence[0];
        for (int i = 1; i < sequence.Length; i++)
        {
            if (max < sequence[i])
            {
                max = sequence[i];
            }
        }

        Console.WriteLine("The maximal number is {0}", max);

        int min = sequence[0];
        for (int i = 1; i < sequence.Length; i++)
        {
            if (min > sequence[i])
            {
                min = sequence[i];
            }
        }

        Console.WriteLine("The minimal number is {0}", min);
    }
}