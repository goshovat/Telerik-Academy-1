using System;
using System.Text.RegularExpressions;

/*
    Write a program for extracting all email addresses from given text. All substrings that 
    match the format <identifier>@<host>…<domain> should be recognized as emails.
*/

class ExtractEmailAddresses
{
    static void Main(string[] args)
    {
        Console.Title = "Extract email addresses from a text";

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter a text: ");
        string text = Console.ReadLine();

        string pattern = @"[a-zA-Z]+@[a-zA-Z]+\.[a-zA-Z]+"; // @"\w+@\w+\.\w+"; 
                         
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThe email addresses in the text are");
        Console.Write(new string('-', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            Console.WriteLine("{0}", match);
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string('-', Console.WindowWidth));

        Console.WriteLine();
        Console.ResetColor();
    }
}