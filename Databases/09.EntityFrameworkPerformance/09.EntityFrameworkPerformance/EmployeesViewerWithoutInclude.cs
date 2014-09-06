﻿namespace _09.EntityFrameworkPerformance
{
    using System;
    using System.Diagnostics;
    using TelerikAcademy;

    public class EmployeesViewerWithoutInclude
    {
        public static void Main(string[] args)
        {
            var context = new TelerikAcademyEntities();
            
            var format = "\nName: {0} {1} {2} \nDepartment: {3} \nTown: {4}";

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var employee in context.Employees)
            {
                Console.WriteLine(format, employee.FirstName, employee.MiddleName, employee.LastName, employee.Department.Name
                    , employee.Address.Town.Name);
            }

            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Yellow;
            var timerFormat = "\nTime: {0} \nTotal Queries: {1}";
            var totalQueries = "340, see the EmployeesViewerWithoutInclude.xlsx";
            Console.WriteLine(timerFormat, stopwatch.Elapsed, totalQueries);
        }
    }
}
