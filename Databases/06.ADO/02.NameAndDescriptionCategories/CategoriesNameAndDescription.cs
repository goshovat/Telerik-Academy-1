namespace _02.NameAndDescriptionCategories
{
    using System;
    using System.Data.SqlClient;

    public class CategoriesNameAndDescription
    {
        public static void Main(string[] args)
        {
            var sqlConnectionString = "Server=.\\; Database=NorthWind; Integrated Security=true";

            var dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                var query = "SELECT CategoryName, Description FROM Categories";

                var categoriesNameAndDescription = new SqlCommand(query, dbCon);
                var reader = categoriesNameAndDescription.ExecuteReader();
                
                using (reader)
                {
                    var message = "{0} - {1}";

                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];

                        Console.WriteLine(message, name, description);
                    }
                }
            }
        }
    }
}
