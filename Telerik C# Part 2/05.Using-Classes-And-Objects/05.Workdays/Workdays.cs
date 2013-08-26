using System;

/*
    Write a method that calculates the number of workdays between today
    and given date, passed as parameter. Consider that workdays are all days 
    from Monday to Friday except a fixed list of public holidays specified 
    preliminary as array.
*/

class Workdays
{
    private DateTime now;
    private DateTime futureDate;
    private DateTime[] publicHolidays = new DateTime[] {
        new DateTime( DateTime.Now.Year, 1, 1),
        new DateTime( DateTime.Now.Year, 3, 3),
        new DateTime( DateTime.Now.Year, 5, 1),
        new DateTime( DateTime.Now.Year, 5, 2),
        new DateTime( DateTime.Now.Year, 5, 3),
        new DateTime( DateTime.Now.Year, 5, 6),
        new DateTime( DateTime.Now.Year, 5, 24),
        new DateTime( DateTime.Now.Year, 8, 14),
        new DateTime( DateTime.Now.Year, 8, 28),
        new DateTime( DateTime.Now.Year, 9, 6),
        new DateTime( DateTime.Now.Year, 9, 22),
        new DateTime( DateTime.Now.Year, 12, 24),
        new DateTime( DateTime.Now.Year, 12, 25),
        new DateTime( DateTime.Now.Year, 12, 26),
        new DateTime( DateTime.Now.Year, 12, 31),
    };

    public Workdays(DateTime futureDate)
    {
        this.now = DateTime.Now;
        this.futureDate = futureDate;
    }

    public int CountWorkdays()
    {
        int countDays = 0;

        while (this.now < this.futureDate)
        {
            if (now.DayOfWeek.ToString().Equals("Saturday") || now.DayOfWeek.ToString().Equals("Sunday"))
            {
                this.now = this.now.AddDays(1);
            }
            else if (isHoliday())
            {
                this.now = this.now.AddDays(1);
            }
            else
            {
                countDays++;
                this.now = this.now.AddDays(1);
            }
        } 
        return countDays;
    }

    public bool isHoliday()
    {
        for (int i = 0; i < publicHolidays.Length; i++)
        {
            if (this.now.Month == this.publicHolidays[i].Month && this.now.Day == this.publicHolidays[i].Day)
            {
                return true;
            }
        }
        return false;
    }

    static void Main(string[] args)
    {
        Console.Title = "Workdays to given date";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter the month: ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter the day: ");
        int day = int.Parse(Console.ReadLine());

        Workdays workdays = new Workdays( new DateTime(DateTime.Now.Year, month, day));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYou have {0} workdays to {1}.{2}.{3}", workdays.CountWorkdays(), day, month, DateTime.Now.Year);

        Console.WriteLine();
        Console.ResetColor();
    }
}