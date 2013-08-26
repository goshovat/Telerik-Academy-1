using System;

// Write a program that prints to the console which day of the week is today. Use System.DateTime.

class DayOfTheWeek
{
    private DateTime currentDate;

    public DayOfTheWeek()
    {
        this.currentDate = DateTime.Now;
    }

    public string Day
    {
        get
        {
            return this.currentDate.DayOfWeek.ToString();
        }

    }

    static void Main(string[] args)
    {
        Console.Title = "Day of the week";

        DayOfTheWeek now = new DayOfTheWeek();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Current day of the week is {0}", now.Day);
        
        Console.WriteLine();
        Console.ResetColor();
    }
}