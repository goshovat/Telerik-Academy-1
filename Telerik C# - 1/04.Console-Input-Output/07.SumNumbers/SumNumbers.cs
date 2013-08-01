using System;

// Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

class SumNumbers
{
    static void Main(string[] args)
    {
        Console.Title = "Suming numbers";

        Console.Write("Enter how many numbers you want to sum : ");
        int numbers = int.Parse(Console.ReadLine());
        int sum = 0;

        for (int i = 0; i < numbers; i++)
        {
            Console.Write("Enter a number [{0}] = ", i + 1);
            sum += int.Parse(Console.ReadLine()); // Reading int value from the console and add it to the sum
        }

        Console.WriteLine("The sum of {0} numbers is {1} ", numbers, sum);
    }
}