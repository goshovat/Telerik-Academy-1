using System;
using System.Globalization;

/*
    Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
    Enter the first date: 27.02.2006
    Enter the second date: 3.03.2006
    Distance: 4 days
*/

class NumberOfDays
{
    static void Main(string[] args)
    {
        Console.Title = "Number of days";

        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG"); // CultureInfo.InvariantCulture;

        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the first date: ");
            DateTime firstDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter the second date: ");
            DateTime secondDate = DateTime.Parse(Console.ReadLine());

            TimeSpan daysBetweenTheDates = secondDate - firstDate;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nDistance: {0} days", daysBetweenTheDates.Days);
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou have entered a wrong date !!!");
        }
        finally
        {
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}