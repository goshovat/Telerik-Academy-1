using System;

/*
    Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 
    0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
    Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.
*/

class PrintSumOfFibonacciMembers
{
    static void Main(string[] args)
    {
        Console.Title = "Fibonnacci sequence";
        int n;
        do
        {
            Console.Write("Enter the number of the last Fibonacci number : ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        // I used decimal types because the big value of numbers
        decimal number = 0;
        decimal numberBefore = 1;
        decimal temporaryNumber;
        decimal sum = 0;

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Number [{0}] = {1}", i, number);
            sum += number;
            temporaryNumber = number;
            number = number + numberBefore;
            numberBefore = temporaryNumber;
        }
        Console.WriteLine("Sum = {0}", sum);
    }
}