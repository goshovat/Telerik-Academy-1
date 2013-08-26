using System;

/*
    A dictionary is stored as a sequence of text lines containing words and 
    their explanations. Write a program that enters a word and translates it 
    by using the dictionary. Sample dictionary:
    .NET – platform for applications from Microsoft
    CLR – managed execution environment for .NET
    namespace – hierarchical organization of classes
*/

class Dictionary
{
    static void Main(string[] args)
    {
        Console.Title = "Dictionary";

        string[] dictionary = {
                                  ".NET – platform for applications from Microsoft",
                                  "CLR – managed execution environment for .NET",
                                  "namespace – hierarchical organization of classes"
                              };

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        Console.WriteLine();
        bool isMissing = true;

        for (int i = 0; i < dictionary.Length; i++)
        {
            if (dictionary[i].IndexOf(word, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(dictionary[i]);
                isMissing = false;
                break;
            }         
        }

        if (isMissing)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The word is not in the dictionary!!!");
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}