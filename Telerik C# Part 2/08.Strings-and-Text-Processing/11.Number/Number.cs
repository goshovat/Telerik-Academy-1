using System;

/*
    Write a program that reads a number and prints it as a decimal number, hexadecimal number, 
    percentage and in scientific notation. Format the output aligned right in 15 symbols.
*/

class Number
{
    static void Main(string[] args)
    {
        Console.Title = "Number";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Decimal number = {0:D}", number);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Hexadecimal number = {0:X}", number);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Percentage = {0:P}", number); 

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Scientific notation = {0:E}", number);

        Console.WriteLine();
        Console.ResetColor();
    }
}