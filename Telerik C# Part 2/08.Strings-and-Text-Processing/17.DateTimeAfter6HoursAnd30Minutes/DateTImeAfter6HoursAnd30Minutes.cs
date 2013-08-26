using System;
using System.Globalization;
using System.Threading;

/*
    Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
    and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
*/

class DateTImeAfter6HoursAnd30Minutes
{
    static void Main(string[] args)
    {
        Console.Title = "Date and time after 6 hours and 30 minutes";

        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a date and time: ");
        string dateAndTime = Console.ReadLine();

        try
        {
            DateTime date = DateTime.ParseExact(dateAndTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            TimeSpan after = new TimeSpan(6, 30, 0);
            date = date.Add(after);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nThe date after 6 hours and 30 minutes is: {0} {1:dd.MM.yyyy hh:mm:ss}", date.ToString("dddd"), date);
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou have entered a wrong date or time!!!");
        }
        finally
        {
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}