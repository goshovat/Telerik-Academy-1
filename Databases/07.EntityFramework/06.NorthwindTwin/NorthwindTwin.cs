namespace _06.NorthwindTwin
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    using Northwind;

    /// <summary>
    /// Create a database called NorthwindTwin with the same structure as Northwind using 
    /// the features from DbContext. Find for the API for schema generation in MSDN or in Google.
    /// </summary>
    public class NorthwindTwin
    {
        public static void Main(string[] args)
        {
            IObjectContextAdapter northwindEntities = new NorthwindEntities();
            var cloneNorthwind = northwindEntities.ObjectContext.CreateDatabaseScript();

            var createNorthwindTwin = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
            "(NAME = NorthwindTwin, " +
            "FILENAME = 'C:\\NorthwindTwin.mdf', " +
            "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            "LOG ON (NAME = NorthwindTwinLog, " +
            "FILENAME = 'C:\\NorthwindTwin.ldf', " +
            "SIZE = 1MB, " +
            "MAXSIZE = 5MB, " +
            "FILEGROWTH = 10%)";
    
            var connectionStringForCreating = "Server=LOCALHOST;Database=master;Integrated Security=true";

            var connectionForCreating = new SqlConnection(connectionStringForCreating);

            connectionForCreating.Open();

            var createDB = new SqlCommand(createNorthwindTwin, connectionForCreating);
            createDB.ExecuteNonQuery();
            
            var connectionStringForClosing = "Server=LOCALHOST;Database=NorthwindTwin;Integrated Security=true";

            var connectionForClosing = new SqlConnection(connectionStringForClosing);

            connectionForClosing.Open();

            var cloneDB = new SqlCommand(cloneNorthwind, connectionForClosing);
            cloneDB.ExecuteNonQuery();

            Console.WriteLine("The database NorthwindTwin was created!");
        }
    }
}
