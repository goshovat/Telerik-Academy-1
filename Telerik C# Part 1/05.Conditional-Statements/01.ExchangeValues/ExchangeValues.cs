using System;

/*
    Write an if statement that examines two integer variables and exchanges their values 
    if the first one is greater than the second one.
*/

class ExchangeValues
{
    static void Main(string[] args)
    {
        Console.Title = "Exchange values";
        Console.Write("Enter the first number : ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number : ");
        int secondNumber = int.Parse(Console.ReadLine());

        if (firstNumber > secondNumber)
        {
            firstNumber = firstNumber + secondNumber;
            secondNumber = firstNumber - secondNumber;
            firstNumber = firstNumber - secondNumber;
        }
        Console.WriteLine("\nFirst number is : {0}\nSecond number : {1}", firstNumber, secondNumber);
    }
}