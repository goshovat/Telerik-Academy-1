using System;

/*
    Write a method GetMax() with two parameters that returns the bigger of two integers. 
    Write a program that reads 3 integers from the console and prints the biggest 
    of them using the method GetMax().
*/

class MaxNumber
{
    public static int GetMax(int first, int second)
    {
        int max = first;

        if (max < second)
        {
            max = second;
        }

        return max;
    }

    static void Main(string[] args)
    {
        Console.Title = "Print max number";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe max number is {0}\n", GetMax(GetMax(firstNumber, secondNumber), thirdNumber));

        Console.ResetColor();
    }
}