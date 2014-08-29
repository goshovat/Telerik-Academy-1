namespace _05.SalesBySpecificRegionAndPeriod
{
    using System;
    using System.Linq;

    using Northwind;

    public class SalesBySpecificRegionAndPeriod
    {
        public static void Main(string[] args)
        {
            var fromDate = new DateTime(1995, 5, 1);
            var toDate = new DateTime(1998, 8, 1);
            var region = "rj";

            FindSalesBySpecifiedRegionAndPeriod(region, fromDate, toDate);
        }

        /// <summary>
        /// Write a method that finds all the sales by specified region and period (start / end dates).
        /// </summary>
        /// <param name="region">Sale's region</param>
        /// <param name="startDate">Sales from date</param>
        /// <param name="endDate">Sales to date</param>
        private static void FindSalesBySpecifiedRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            var northwindEntities = new NorthwindEntities();

            var sales = northwindEntities.Orders.Where(o => (startDate < o.OrderDate && o.OrderDate < endDate) && o.ShipRegion == region);


            var pattern = "OrderID: {0} \nCustomerID: {1} \nEmployeeID: {2} \nOrderDate: {3} \nRequiredDate: {4} " +
                            "\nShippedDate: {5} \nShipVia: {6} \nFreight: {7} \nShipName: {8} \nShipAddress: {9} \nShipCity: {10} " +
                            "\nShipRegion: {11} \nShipPostalCode: {12} \nShipCountry: {13} \n";

            foreach (var sale in sales)
            {
                Console.WriteLine(pattern, sale.OrderID, sale.CustomerID, sale.EmployeeID, sale.OrderDate, sale.RequiredDate, sale.ShippedDate,
                                    sale.ShipVia, sale.Freight, sale.ShipName, sale.ShipAddress, sale.ShipCity, sale.ShipRegion, sale.ShipPostalCode, sale.ShipCountry);
            }
        }
    }
}
