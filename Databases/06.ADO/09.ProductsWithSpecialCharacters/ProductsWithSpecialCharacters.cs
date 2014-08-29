namespace _09.ProductsWithSpecialCharacters
{
    using System;
    using System.Data.SqlClient;

    public class ProductsWithSpecialCharacters
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a string that you want to search in products: ");
            var word = Console.ReadLine();

            word.Replace("%", "[%]");
            word.Replace("_", "[_]");

            var sqlConnectionString = "Server=.\\; Database=NorthWind; Integrated Security=true";

            var dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                var query = @"SELECT ProductName FROM products WHERE ProductName LIKE @word ESCAPE '\'";

                var categoriesNameAndProduct = new SqlCommand(query, dbCon);
                categoriesNameAndProduct.Parameters.AddWithValue("@word", "%" + word + "%");
                
                var reader = categoriesNameAndProduct.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine(productName);
                    }
                }
            }
        }
    }
}
