namespace _09.AddingOrder
{
    using System;
    using System.Transactions;

    using Northwind;

    /// <summary>
    /// Create a method that places a new order in the Northwind database. 
    /// The order should contain several order items. Use transaction to ensure the data consistency.
    /// </summary>
    public class AddingOrder
    {
        public static void Main(string[] args)
        {
            using (var scope = new TransactionScope())
            {
                InsertManyOrder(10);                
                scope.Complete();
            }
        }

        private static void InsertManyOrder(int max)
        {
            for (int i = 0; i < max; i++)
            {
                InsertOrder();
            }
        }   

        private static void InsertOrder(string shipName = null, string shipAddress = null, string shipCity = null, string shipRegionm = null, 
            string shipPostalCode = null, string shipCountry = null, string customerID = null, int? employeeID = null, DateTime? orderDate = null, 
            DateTime? requiredDate = null, DateTime? shippedDate = null, int? shipVia = null, decimal? freight = null)
        {
            using (var context = new NorthwindEntities())
            {
                Order newOrder = new Order
                {
                    ShipAddress = shipAddress,
                    ShipCity = shipCity,
                    ShipCountry = shipCountry,
                    ShipName = shipName,
                    ShippedDate = shippedDate,
                    ShipPostalCode = shipPostalCode,
                    ShipRegion = shipRegionm,
                    ShipVia = shipVia,
                    EmployeeID = employeeID,
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    Freight = freight,
                    CustomerID = customerID
                };

                context.Orders.Add(newOrder);

                context.SaveChanges();

                Console.WriteLine("Row is inserted.");
            }
        }  
    }
}
