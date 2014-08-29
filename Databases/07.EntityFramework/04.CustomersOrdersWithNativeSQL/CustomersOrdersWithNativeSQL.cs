namespace _04.CustomersOrdersWithNativeSQL
{
    using System;

    using Northwind;

    public class CustomersOrdersWithNativeSQL
    {
        public static void Main(string[] args)
        {
            var date = new DateTime(1997, 1, 1);
            var country = "Canada";

            FindCustomersOrders(date, country);
        }

        /// <summary>
        /// Implement previous by using native SQL query and executing it through the DbContext.
        /// </summary>
        /// <param name="date">Date of the order</param>
        /// <param name="country">Country of the order</param>
        private static void FindCustomersOrders(DateTime date, string country)
        {
            var northwindEntities = new NorthwindEntities();
            string nativeSqlQuery = "SELECT c.ContactName, o.OrderDate, o.ShipName, o.ShipCountry  FROM dbo.Customers AS c " +
                "INNER JOIN dbo.orders AS o ON c.CustomerID = o.CustomerID " +
                "WHERE year(o.OrderDate) = '" + date.Year + "'  AND o.ShipCountry = '" + country + "'";

            var customersOrders = northwindEntities.Database.SqlQuery<CustomerOrder>(nativeSqlQuery);

            var format = "ContactName Name: {0} \nOrder Date: {1} \nShip Name: {2} \nShipCountry: {3} \n";

            foreach (var order in customersOrders)
            {
                Console.WriteLine(format, order.ContactName, order.OrderDate, order.ShipName, order.ShipCountry);
            }
        }
    }
}
