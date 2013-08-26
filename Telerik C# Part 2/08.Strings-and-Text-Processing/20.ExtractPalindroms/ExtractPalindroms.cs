using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

/*
    Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
*/

class ExtractPalindroms
{
    public static void CheckWord(string word)
    {
        bool isPalindrom = true;

        string checkedString = RemoveWitheSpaces(word).ToLower();

        for (int i = 0; i < checkedString.Length / 2; i++)
        {
            if (checkedString[i] != checkedString[checkedString.Length - i - 1])
            {
                isPalindrom = false;
                break;
            }
        }
        if (isPalindrom)
        {
            Console.WriteLine("{0}\n", word.Trim());       
        }
    }

    public static string RemoveWitheSpaces(string words)
    {
        StringBuilder word = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] != ' ')
            {
                word.Append(words[i]);
            }
        }

        return word.ToString();
    }

    static void Main(string[] args)
    {
        Console.Title = "Extract palindroms from a text";

        //Console.ForegroundColor = ConsoleColor.Cyan;
        //Console.Write("Enter a text: ");
        //string text = Console.ReadLine();

        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        string text = @"Ядох. Е, щом си пял, ако има нужда, мини да ги видиш у дома — саксиен демон ръкомаха мокър, но мед не иска — само души диви гадини... Маджуна ми окаля писмо. Ще ходя!";

        string[] separator = { ".", ",", "!", " ", "?", ":", ";", "—", "-", "\"", "'" };

        string[] separatedWords = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);


        List<string> words = new List<string>();

        for (int i = 0; i < separatedWords.Length; i++)
        {
            StringBuilder appender = new StringBuilder();
            for (int j = i; j < separatedWords.Length; j++)
            {
                appender.Append(separatedWords[j]);
                appender.Append(" ");
                words.Add(appender.ToString());
            }
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThe palindroms in the text are:");
        Console.Write(new string('-', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < words.Count; i++)
        {
            CheckWord(words[i]);       
        }
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string('-', Console.WindowWidth));

        Console.WriteLine();
        Console.ResetColor();

    }
}