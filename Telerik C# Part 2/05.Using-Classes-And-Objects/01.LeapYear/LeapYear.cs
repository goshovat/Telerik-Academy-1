using System;

// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

class LeapYear
{
    private DateTime date;

    // Constructor
    public LeapYear(DateTime date)
    {
        this.date = date;
    }

    // Return the current year
    public int Year
    {
        get
        {
            return date.Year;
        }
    }

    // Check if the year is leap
    public bool IsLeap()
    {
        bool isLeap = false;

        if (this.Year % 4 == 0 && this.Year % 100 != 0  || this.Year % 400 == 0)
        {
            isLeap = true;
        }

        return isLeap;
    }

    static void Main(string[] args)
    {
        Console.Title = "Leap year";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter an year: ");

        DateTime date = new DateTime(int.Parse(Console.ReadLine()), 1, 1);

        LeapYear leapYear = new LeapYear(date);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nIs the year {0} is leap ?", leapYear.Year); // Calling the property and get the year
        Console.WriteLine("---> Answer: {0} <---", leapYear.IsLeap()); // Calling the method and check the year

        // Embedded method to check the result
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n===> Answer: {0} <=== Embedded method for check", DateTime.IsLeapYear(leapYear.Year));
 
        Console.WriteLine();
        Console.ResetColor();
    }
}