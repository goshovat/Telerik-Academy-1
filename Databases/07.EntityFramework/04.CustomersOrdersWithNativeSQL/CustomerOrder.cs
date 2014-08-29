namespace _04.CustomersOrdersWithNativeSQL
{
    using System;

    public class CustomerOrder
    {
        public string ContactName { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }
    }
}
