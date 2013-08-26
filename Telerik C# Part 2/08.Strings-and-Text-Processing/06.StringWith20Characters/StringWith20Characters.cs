using System;
using System.Text;

/*
    Write a program that reads from the console a string of maximum 20 characters. 
    If the length of the string is less than 20, the rest of the characters should
    be filled with '*'. Print the result string into the console.
*/

class StringWith20Characters
{
    static void Main(string[] args)
    {
        Console.Title = "String with 20 characters";

        string text;

        Console.ForegroundColor = ConsoleColor.Green;

        do
        {
            Console.Write("Enter a string with maximum 20 characters: ");
            text = Console.ReadLine();
        } while (text.Length > 19);

        int lengthOfStars = 20 - text.Length;
      
        text += new string('*', lengthOfStars);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n12345678901234567890 <--- Indexator"); // Indexator of the characters
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("{0}", text);

        Console.WriteLine();
        Console.ResetColor();
    }
}