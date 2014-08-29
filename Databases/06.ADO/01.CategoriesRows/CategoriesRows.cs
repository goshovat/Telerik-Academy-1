namespace _01.CategoriesRows
{
    using System;
    using System.Data.SqlClient;

    public class CategoriesRows
    {
        public static void Main(string[] args)
        {
            var sqlConnectionString = "Server=.\\; Database=NorthWind; Integrated Security=true";

            var dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                var query = "SELECT COUNT(*) FROM Categories";

                var cmdCount = new SqlCommand(query, dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();

                var message = "Categories count: {0} ";
                Console.WriteLine(message, categoriesCount);
            }
        }
    }
}
