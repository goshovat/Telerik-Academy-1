using System;

// Write a program that finds the biggest of three integers using nested if statements.

class FindBiggestNumber
{
    static void Main(string[] args)
    {
        Console.Title = "Finding the biggest number";
        Console.Write("Enter the first number : ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number : ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the third number : ");
        int thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber > secondNumber)
        {
            if (firstNumber > thirdNumber)
            {
                Console.WriteLine("The first number is the biggest!");
            }
            else
            {
                Console.WriteLine("The third number is the biggest!");
            }
        }
        else
        {
            if (secondNumber > thirdNumber)
            {
                Console.WriteLine("The second number is the biggest!");
            }
            else
            {
                Console.WriteLine("The third number is the biggest!");
            }
        }
    }
}