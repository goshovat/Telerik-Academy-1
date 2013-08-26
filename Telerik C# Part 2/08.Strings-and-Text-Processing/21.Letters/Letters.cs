using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/*
    Write a program that reads a string from the console and prints all different letters 
    in the string along with information how many times each letter is found.  
*/

class Letters
{
    static void Main(string[] args)
    {
        Console.Title = "Letter in a string";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        char[] letters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 
                             'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        int[] counter = new int[letters.Length];

        text = text.ToLower();

        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (text[i] == letters[j])
                {
                    counter[j]++;
                }
            } 
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThe letters in the string are:");
        Console.WriteLine(new string('-', 30));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < letters.Length; i++)
        {
            if (counter[i] != 0)
            {
                Console.WriteLine("{0} - {1} times", letters[i], counter[i]);
            }
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(new string('-', 30));

        Console.WriteLine();
        Console.ResetColor();
    }
}