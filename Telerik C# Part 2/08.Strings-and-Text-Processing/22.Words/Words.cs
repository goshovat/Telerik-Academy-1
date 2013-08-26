using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/*
    Write a program that reads a string from the console and lists all different 
    words in the string along with information how many times each word is found.
*/

class Words
{
    static void Main(string[] args)
    {
        Console.Title = "Words counter";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        List<string> wordsToFind = new List<string>(Regex.Split(text, @"\W+", RegexOptions.IgnorePatternWhitespace));

        // Remove duplicates words
        for (int i = 0; i < wordsToFind.Count; i++)
        {
            for (int j = i + 1; j < wordsToFind.Count; j++)
            {
                if (wordsToFind[i] == wordsToFind[j])
                {
                    wordsToFind.RemoveAt(j);
                    j--;
                }
            }
        }

        int[] times = new int[wordsToFind.Count];

        // Count the words
        for (int i = 0; i < wordsToFind.Count; i++)
        {
            times[i] = Regex.Matches(text, string.Format(@"\b{0}\b", wordsToFind[i])).Count;
        }

        // Print the result
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThe words in the string are:");
        Console.WriteLine(new string('-', 30));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < wordsToFind.Count; i++)
        {
            Console.WriteLine("{0} - {1} times", wordsToFind[i], times[i]);
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(new string('-', 30));

        Console.WriteLine();
        Console.ResetColor();
    }
}