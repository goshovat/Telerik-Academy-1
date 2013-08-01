using System;

/*
    Write a program that calculates the greatest common divisor (GCD) of given two numbers. 
    Use the Euclidean algorithm (find it in Internet).
*/

class GCD
{
    static void Main(string[] args)
    {
        Console.Title = "Greatest common divisor";

        Console.Write("Enter the first number : ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number : ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("The greatest common divisor is {0}", EuclidGCD(firstNumber, secondNumber));
    }

    static int EuclidGCD(int x, int y)
    {
        if (y == 0)
        {
            return x;
        }
        else
        {
            return EuclidGCD(y, x % y);
        }
    }
}