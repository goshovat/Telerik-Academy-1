using System;
using System.Text.RegularExpressions;

/*
    Write a program that extracts from a given text all sentences containing given word.
		Example: The word is "in". The text is:
    We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. 
    So we are drinking all the day. We will move out of it in 5 days.
    
    The expected result is:
        We are living in a yellow submarine.
        We will move out of it in 5 days.
*/

class ExtractSentances
{
    static void Main(string[] args)
    {
        Console.Title = "Extract sentences with the word \"in\" in them";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a string: ");
        string text = Console.ReadLine();
       //string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight." + 
       //              "So we are drinking all the day. We will move out of it in 5 days."; 

        Console.Write("Enter word: ");
        string word = Console.ReadLine();

        string[] separator = {". ", "."};
        string[] sentences = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        bool hasIn = false;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe sentences that contain the word \"in\" are:");
        Console.WriteLine(new string('-', 50));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < sentences.Length; i++)
        {
            if (Regex.IsMatch(sentences[i], string.Format(@"\b{0}\b", word)))
            {
                Console.WriteLine("{0}.", sentences[i]);
                hasIn = true;
            }
        }

        if (!hasIn)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The are no sentences with the word \"in\" in them!!!");
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 50));

        Console.WriteLine();
        Console.ResetColor();
    }
}