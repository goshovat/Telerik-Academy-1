namespace _02.CustomerDAO
{
    using System.Linq;
    
    using Northwind;

    /// <summary>
    /// Create a DAO class with static methods which provide functionality for inserting, modifying and 
    /// deleting customers. Write a testing class.
    /// </summary>
    public class CustomerDAO
    {
        private static readonly NorthwindEntities northwindEntities = new NorthwindEntities();

        public static void Insert(string customerID, string companyName, string contactName, string contactTitle, 
            string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            var newCustomer = new Customer
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode, 
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };

            northwindEntities.Customers.Add(newCustomer);
            northwindEntities.SaveChanges();
        }


        public static void UpdateCompanyName(string customerID, string newCompanyName)
        {
            var customers = northwindEntities.Customers.Where(c => c.CustomerID == customerID).Select(c => c);

            foreach (var customer in customers)
            {
                customer.CompanyName = newCompanyName;
            }

            northwindEntities.SaveChanges();
        }

        public static void UpdateContactName(string customerID, string newConactName)
        {
            var customers = northwindEntities.Customers.Where(c => c.CustomerID == customerID).Select(c => c);

            foreach (var customer in customers)
            {
                customer.ContactName = newConactName;
            }

            northwindEntities.SaveChanges();
        }

        public static Customer Delete(string customerID)
        {
            var customer = northwindEntities.Customers.Where(c => c.CustomerID == customerID).Select(c => c).First();

            customer = northwindEntities.Customers.Remove(customer);
           
            northwindEntities.SaveChanges();

            return customer;
        }
    }
}
