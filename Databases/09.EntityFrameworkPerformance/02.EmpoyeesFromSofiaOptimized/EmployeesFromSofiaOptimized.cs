namespace _02.EmpoyeesFromSofiaOptimized
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    using TelerikAcademy;

    public class EmployeesFromSofiaOptimized
    {
        public static void Main(string[] args)
        {

            var context = new TelerikAcademyEntities();

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            const string chosenTown = "sofia";

            var employeesFromSofia = context.Employees.Join(
                context.Addresses,
                e => e.AddressID,
                a => a.AddressID,
                (e, a) => new 
                    {
                        TownId = a.TownID
                    }                
            )
                .Join(
                    context.Towns,
                    e => e.TownId,
                    t => t.TownID,
                    (e, t) => new
                        {
                            TownName = t.Name
                        }
                )
                .Where(t => t.TownName == chosenTown).ToList();

            stopwatch.Stop();

            var format = "Execution time: {0} \nTotal Queries: {1}";
            var totalQueries = "1, see the EmployeesFromSofia.xlsx";
            Console.WriteLine(format, stopwatch.Elapsed, totalQueries);
        }
    }
}
