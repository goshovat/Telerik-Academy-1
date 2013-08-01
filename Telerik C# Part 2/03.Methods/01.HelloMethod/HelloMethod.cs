using System;

/*
    Write a method that asks the user for his name and prints “Hello, <name>” 
    (for example, “Hello, Peter!”). Write a program to test this method.
*/

class HelloMethod
{
    public static void SayHello()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nHello, {0}!\n", name);
    }

    static void Main(string[] args)
    {
        Console.Title = "Hello";
        SayHello();

        Console.ResetColor();
    }
}