using System;

    /*
        Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
    */

class Exchange
{
    static void Main(string[] args)
    {
        int number1 = 5;
        int number2 = 10;
        int temporaryNumber;
        Console.WriteLine("Before exchange, first number - {0}, second number - {1}.", number1, number2);
        //first way to exchange numbers - with additional variable
        temporaryNumber = number1;
        number1 = number2;
        number2 = temporaryNumber;
        Console.WriteLine("After exchange, first number - {0}, second number - {1}.", number1, number2);
        //second way to exchange numbers - with arithmetic expressions
        number1 = number1 + number2;
        number2 = number1 - number2;
        number1 = number1 - number2;
        Console.WriteLine("After exchange back, first number - {0}, second number - {1}.", number1, number2);
    }
}
