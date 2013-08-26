using System;
using System.Text;
using System.Text.RegularExpressions;

/*
    Write a program that reverses the words in given sentence.
	Example: "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!". 
*/

class ReverseSentence
{
    static void Main(string[] args)
    {
        Console.Title = "Reverse sentence";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        char[] separator = {' ', ',', '.', '!', '?'};
        string[] words = sentence.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        string[] wordsArray = sentence.Split(' ');
        StringBuilder changedSentence = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] != wordsArray[i])
            {
                changedSentence.Append(words[words.Length - 1 - i]);
                changedSentence.Append(wordsArray[i][wordsArray[i].Length - 1]);
                changedSentence.Append(' ');
            }
            else
            {
                changedSentence.Append(words[words.Length - 1 - i]);
                changedSentence.Append(' ');
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe reversed sentence is : {0}", changedSentence);

        Console.WriteLine();
        Console.ResetColor();
    }
}