using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

/*
    Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
    Display them in the standard date format for Canada.
*/

class ExtractDates
{
    static void Main(string[] args)
    {
        Console.Title = "Extract dates in format DD.MM.YYYY";

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Enter a text: ");
        string text = Console.ReadLine();

        string pattern = @"(\b[0-9]{2}\b).(\b[0-9]{2}\b).(\b[0-9]{4}\b)";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThe dates in the text are:");
        Console.Write(new string('-', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            DateTime dateInCanada;
            if (DateTime.TryParseExact(match.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateInCanada))
            {
                Console.WriteLine(dateInCanada.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string('-', Console.WindowWidth));

        Console.WriteLine();
        Console.ResetColor();    
    }
}