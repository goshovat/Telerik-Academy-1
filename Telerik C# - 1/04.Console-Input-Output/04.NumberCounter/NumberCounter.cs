using System;

/*
    Write a program that reads two positive integer numbers and prints how many numbers p exist 
    between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.
*/

class NumberCounter
{
    static void Main(string[] args)
    {
        Console.Title = "Counting numbers";

        Console.Write("Enter the numeber you want to start from : ");
        uint startNumber = uint.Parse(Console.ReadLine());

        Console.Write("Enter the numeber, where you want to stop checking : ");
        uint stopNumber = uint.Parse(Console.ReadLine());

        uint numberCounter = 0;
        for (uint i = startNumber; i <= stopNumber; i++)
        {
            if (i % 5 == 0)
            {
                numberCounter++;
            }
        }
        Console.WriteLine("\nHow many number p exist between {0} and {1} such that the reminder of the division by 5 is 0 ?", startNumber, stopNumber);
        Console.WriteLine("Answer : {0}", numberCounter);
    }
}
