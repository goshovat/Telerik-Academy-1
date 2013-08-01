using System;

/* 
    Write a program that reads an integer number n from the console
    and prints all the numbers in the interval [1..n], each on a single line.
*/

class PrintSequence
{
    static void Main(string[] args)
    {
        Console.Title = "Print sequence from 1 to n";

        Console.Write("Enter the number, where the sequence must stop : ");
        int stopPoint = int.Parse(Console.ReadLine());

        for (int i = 1; i <= stopPoint; i++)
        {
            Console.WriteLine(i);
        }
    }
}