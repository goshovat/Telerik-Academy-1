using System;

//Write a program that reads 3 integer numbers from the console and prints their sum.

class SumInteger
{
    static void Main(string[] args)
    {
        Console.Title = "Print the sum of 3 integer";
        int firstNumber, secondNumber, thirdNumber, sumNumbers;

        Console.Write("Please, enter the first number : ");
        firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Please, enter the second number : ");
        secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Please, enter the third number : ");
        thirdNumber = int.Parse(Console.ReadLine());

        sumNumbers = firstNumber + secondNumber + thirdNumber;
        Console.WriteLine("\nTheir sum is = {0}", sumNumbers);
    }
}