using System;

// Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …


class PrintFibonacciSequence
{
    static void Main(string[] args)
    {
        Console.Title = "Fibonnacci sequence";
        // I used decimal types because the range of the last numbers are too big
        decimal number = 0;
        decimal numberBefore = 1;
        decimal temporaryNumber;

        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine("Number [{0}] = {1}", i, number);
            temporaryNumber = number;
            number = number + numberBefore;
            numberBefore = temporaryNumber;
        }
    }
}