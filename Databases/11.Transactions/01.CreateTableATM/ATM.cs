namespace _01.CreateTableATM
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public class ATM
    {
        public static void Main(string[] args)
        {
            var path = "..\\..\\script.sql";

            var script = File.ReadAllText(path);
            var queries = script.Split(new string[]{"GO"}, StringSplitOptions.RemoveEmptyEntries);

            var sqlConnectionString = "Server=.; Database=NorthWind; Integrated Security=true";

            var dbCon = new SqlConnection(sqlConnectionString);
            dbCon.Open();

            using (dbCon)
            {
                foreach (var query in queries)
                {
                    var cmdCount = new SqlCommand(query, dbCon);
                    var result = cmdCount.ExecuteNonQuery();
                }

                Console.WriteLine("The database ATM was created and populated");
            }
        }
    }
}
