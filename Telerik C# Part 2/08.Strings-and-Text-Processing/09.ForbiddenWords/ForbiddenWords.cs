using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

/*
    We are given a string containing a list of forbidden words and a text containing some of these words. 
    Write a program that replaces the forbidden words with asterisks. Example:
    Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and 
    is implemented as a dynamic language in CLR.

	Words: "PHP, CLR, Microsoft"
	The expected result:
    ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and 
    is implemented as a dynamic language in ***.
*/
class ForbiddenWords
{
    static void Main(string[] args)
    {
        Console.Title = "Remove given words from a text";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nEnter a text: ");
        string text = Console.ReadLine(); // "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        Console.Write("Enter forbidden words: ");
        string words = Console.ReadLine(); // "PHP, CLR, Microsoft";

        string[] wordsToRemove = Regex.Split(words, @"\W+");       

        // Replace the words
        for (int i = 0; i < wordsToRemove.Length; i++)
        {
            text = Regex.Replace(text, string.Format(@"\b{0}\b", wordsToRemove[i]), new string('*', wordsToRemove[i].Length));
        }
               
        // Print the changed text
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe contents of the changed text:");
        Console.Write(new string('*', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('*', Console.WindowWidth));

        Console.WriteLine();
        Console.ResetColor();
    }
}