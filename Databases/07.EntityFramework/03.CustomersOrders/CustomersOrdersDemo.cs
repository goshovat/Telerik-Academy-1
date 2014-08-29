namespace _03.CustomersOrders
{
    using System;
    using System.Linq;

    using Northwind;

    public class CustomersOrdersDemo
    {
        public static void Main(string[] args)
        {
            var date = new DateTime(1997, 1, 1);
            var country = "Canada";

            FindCustomersOrders(date, country);
        }

        /// <summary>
        /// Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        /// <param name="data">Date of the order</param>
        /// <param name="country">Country of the order</param>
        private static void FindCustomersOrders(DateTime data, string country)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();

            var customersOrders =
               northwindEntities.Customers.Join(
                   northwindEntities.Orders,
                   (customer => customer.CustomerID),
                   (order => order.CustomerID),
                   (customer, order) => new
                   {
                       ContactName = customer.ContactName,
                       OrderDate = order.OrderDate,
                       ShipName = order.ShipName,
                       ShipCountry = order.ShipCountry
                   }).Where(order => order.OrderDate.Value.Year == data.Year && order.ShipCountry == country);


            var format = "Contact Name: {0} \nOrder Date: {1} \nShip Name: {2} \nShipCountry: {3} \n";

            foreach (var order in customersOrders)
            {
                Console.WriteLine(format, order.ContactName, order.OrderDate, order.ShipName, order.ShipCountry);
            }
        }
    }
}
