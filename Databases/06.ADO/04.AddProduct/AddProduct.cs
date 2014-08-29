namespace _04.AddProduct
{
    using System;
    using System.Data.SqlClient;

    public class AddProduct
    {
        public static void Main(string[] args)
        {
            InsertProduct("Chushki", 1, 1, "56 kg", 2.0m, 10, 0, 0, false);
        }

        private static void InsertProduct(string productName, int supplierID, int categoryID, 
            string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, 
            short reorderLevel, bool discontinued)
        {
            var dbCon = new SqlConnection("Server=.\\; " +
                  "Database=NorthWind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                var query = "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, " +
                    "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                    "VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, " + 
                    "@unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";

                var cmdInsertProject = new SqlCommand(query, dbCon);

                cmdInsertProject.Parameters.AddWithValue("@productName", productName);
                cmdInsertProject.Parameters.AddWithValue("@supplierID", supplierID);
                cmdInsertProject.Parameters.AddWithValue("@categoryID", categoryID);
                cmdInsertProject.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
                cmdInsertProject.Parameters.AddWithValue("@unitPrice", unitPrice);
                cmdInsertProject.Parameters.AddWithValue("@unitsInStock", unitsInStock);
                cmdInsertProject.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
                cmdInsertProject.Parameters.AddWithValue("@reorderLevel", reorderLevel);
                cmdInsertProject.Parameters.AddWithValue("@discontinued", discontinued);

                var rowsAffected = cmdInsertProject.ExecuteNonQuery();
                var message = "{0} row(s) affected";

                Console.WriteLine(message, rowsAffected);
            }
        }
    }
}
