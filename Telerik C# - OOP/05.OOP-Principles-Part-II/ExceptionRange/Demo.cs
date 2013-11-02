namespace ExceptionRange
{
    using System;

    public class Demo
    {
        static void Main(string[] args)
        {
            Console.Title = "Exeption Test";

            int startPoint = 1;
            int endPoint = 100;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter 3 numbers in the range [1, 100]:");
            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < startPoint || number > endPoint)
                {
                    throw new InvalidRangeException<int>(
                        string.Format("The number {2} is not in the range [{0}, {1}]", startPoint, endPoint, number), startPoint, endPoint, number);
                }
                else
                {
                    Console.WriteLine("The number is correct!");
                }
            }

            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter 3 dates in the specified format: dd.mm.yyyy in the range [1980, 2013]:");

            for (int i = 0; i < 3; i++)
            {
                string date = Console.ReadLine();
                DateTime someDate = DateTime.Parse(date);

                if (someDate.Year < startDate.Year || someDate.Year > endDate.Year)
                {
                    throw new InvalidRangeException<DateTime>(
                        string.Format("The date {0} is not in the correct range [{1}, {2}]", someDate.Date, startDate.Date, endDate.Date), 
                        startDate, endDate, DateTime.Now);
                }
                else
                {
                    Console.WriteLine("The date is correct!");
                }
            }
        }
    }
}
