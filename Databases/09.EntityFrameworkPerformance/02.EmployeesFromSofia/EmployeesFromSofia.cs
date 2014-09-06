namespace _02.EmployeesFromSofia
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using TelerikAcademy;

    public class EmployeesFromSofia
    {
        public static void Main(string[] args)
        {
            var context = new TelerikAcademyEntities();

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            const string chosenTown = "sofia";

            var employeesFromSofia = context.Employees
                                        .ToList()
                                        .Select(e => e.Address)
                                        .ToList()
                                        .Select(a => a.Town)
                                        .ToList()
                                        .Where(t => t.Name == chosenTown)
                                        .ToList();

            stopwatch.Stop();

            var format = "Execution time: {0} \nTotal Queries: {1}";
            var totalQueries = "646, see the EmployeesFromSofia.xlsx";
            Console.WriteLine(format, stopwatch.Elapsed, totalQueries);
        }
    }
}
