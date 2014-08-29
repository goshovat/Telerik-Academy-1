namespace _03.CategoriesProducts
{
    using System;
    using System.Data.SqlClient;

    public class CategoriesProducts
    {
        public static void Main(string[] args)
        {

            var sqlConnectionString = "Server=.\\; Database=NorthWind; Integrated Security=true";

            var dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                var query =  "SELECT c.CategoryName, p.ProductName FROM Categories AS c " +
                    "INNER JOIN products AS p ON p.CategoryID = c.CategoryID";

                var categoriesNameAndProduct = new SqlCommand(query, dbCon);
                var reader = categoriesNameAndProduct.ExecuteReader();

                using (reader)
                {
                    var message = "{0} - {1}";

                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine(message, categoryName, productName);
                    }
                }
            }
        }
    }
}
