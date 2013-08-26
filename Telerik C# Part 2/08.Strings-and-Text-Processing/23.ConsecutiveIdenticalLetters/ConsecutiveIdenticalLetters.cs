using System;
using System.Collections.Generic;

/*
    Write a program that reads a string from the console and replaces all series of 
    consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".
*/

class ConsecutiveIdenticalLetters
{
    static void Main(string[] args)
    {
        Console.Title = "Replaces all series of consecutive identical letters with a single one";
      
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter a string: ");
        string text = Console.ReadLine();

        List<char> letters = new List<char>(text.ToCharArray());

        for (int i = 0; i < letters.Count; i++)
        {
            for (int j = i + 1; j < letters.Count; j++)
            {
                if (letters[i] == letters[j])
                {
                    letters.RemoveAt(j);
                    j--;                  
                }
                else
                {
                    break;
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThe text without duplicates:");
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < letters.Count; i++)
        {
            Console.Write(letters[i]);
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(new string('-', 40));
        
        Console.WriteLine("\n");
        Console.ResetColor();
    }
}