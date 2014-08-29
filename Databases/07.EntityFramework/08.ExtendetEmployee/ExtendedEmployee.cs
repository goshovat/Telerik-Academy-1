namespace _08.ExtendetEmployee
{
    using System;
    using System.Linq;

    using Northwind;

    public class ExtendedEmployee
    {
        public static void Main(string[] args)
        {
            var northwindEntities = new NorthwindEntities();

            var employee = northwindEntities.Employees.FirstOrDefault();

            foreach (var territory in employee.EntityTerritories)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }
        }
    }
}
