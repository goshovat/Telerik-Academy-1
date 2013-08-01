using System;

// Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

class CompareNumbers
{
    static void Main(string[] args)
    {
        Console.Title = "Comparing two numbers";

        Console.Write("Enter the first number : ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number : ");
        double secondNumber = double.Parse(Console.ReadLine());

        double greaterNumber = (firstNumber + secondNumber + Math.Abs(firstNumber - secondNumber)) / 2;

        Console.Write("The numbers are ({0} ? {1}) and ", firstNumber, secondNumber);
        Console.WriteLine("the greater number is {0}!", greaterNumber);
    }
}