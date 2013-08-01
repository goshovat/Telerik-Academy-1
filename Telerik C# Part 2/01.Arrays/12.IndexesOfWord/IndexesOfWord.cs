using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Write a program that creates an array containing all letters from the alphabet (A-Z). 
    Read a word from the console and print the index of each of its letters in the array.
*/

class IndexesOfWord
{
    static void Main(string[] args)
    {
        Console.Title = "Indexes of the letters of a word";

        char[] letters = new char[26];

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The array with lettes:");
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0, num = 65; i < 26; i++, num++)
        {
            letters[i] = (char)num;
            Console.WriteLine("   Letter[{0}] = {1}", i, (char)num);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 20));

        Console.Write("\nEnter a word : ");
        string word = Console.ReadLine();

        word = word.ToUpper(); // Make the word in capital letters

        bool hasFound = false;

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\nThe letters and their indexes:");
        Console.WriteLine(new string('-', 30));

        for (int i = 0; i < word.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i].Equals(letters[j]))
                {
                    hasFound = true;
                    Console.WriteLine("The letter {0} has index {1}", word[i], j);
                }
            }
            if (!hasFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The character {0} is not a letter !!!", word[i]);
            }
            hasFound = false;
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(new string('-', 30));
 
        Console.WriteLine();
        Console.ResetColor();
    }
}