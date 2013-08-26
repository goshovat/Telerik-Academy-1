using System;

/*
    Write a program that reads a string, reverses it and prints the result at the console.
    Example: "sample" -> "elpmas".
*/

class ReverseString
{
    public static string Reverse(string word)
    {
        char[] array = word.ToCharArray();

        Array.Reverse(array);

        return new string(array);
    }
    
    static void Main(string[] args)
    {
        Console.Title = "Reverse string";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe reversed string is {0}\n", Reverse(word));

        Console.ResetColor();
    }
}