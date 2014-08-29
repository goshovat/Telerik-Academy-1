namespace _10.TotalIncomeForSupplier
{
    using System;

    using Northwind;

    /// <summary>
    /// Create a stored procedures in the Northwind database for finding the total incomes for 
    /// given supplier name and period (start date, end date). 
    /// Implement a C# method that calls the stored procedure and returns the retuned record set.
    /// </summary>
    public class TotalIncomeForSupplier
    {
        public static void Main(string[] args)
        {
            var totalIncome = GetTotalIncomes("Ma Maison", new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));

            Console.WriteLine(totalIncome);
        }

        private static decimal? GetTotalIncomes(string supplierName, DateTime? startDate, DateTime? endDate)
        {
            using (var northwindEntites = new NorthwindEntities())
            {
                var totalIncomeSet = northwindEntites
                    .usp_GetTotalIncomeForSupplier(supplierName, startDate, endDate);

                foreach (var totalIncome in totalIncomeSet)
                {
                    return totalIncome;
                }
            }

            return null;
        }
    }
}
