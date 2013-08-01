using System;

// Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

class PrintNumbers
{
    static void Main(string[] args)
    {
        Console.Title = "Print numbers from 1 to n, which can't be diveded by 3 and 7 at the sam time";
        Console.Write("Enter the stop point : ");
        int stopPoint = int.Parse(Console.ReadLine());
        Console.WriteLine("\nThe number that are not divisible by 3 and 7 at the same time are :");
        for (int number = 1; number <= stopPoint; number++)
        {
            if (number % 21 != 0)
            {
                Console.WriteLine(number);
            }
        }
    }
}