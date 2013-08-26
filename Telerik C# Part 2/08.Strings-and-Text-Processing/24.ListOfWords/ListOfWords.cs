using System;
using System.Text.RegularExpressions;

// Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

class ListOfWords
{
    static void Main(string[] args)
    {
        Console.Title = "List of words";

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter a string: ");
        string text = Console.ReadLine();

        string[] words = Regex.Split(text, " ");

        Array.Sort(words);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("The sorted words:");
        Console.WriteLine(new string('-', 30));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(new string('-', 30));
        
        Console.WriteLine();
        Console.ResetColor();
    }
}