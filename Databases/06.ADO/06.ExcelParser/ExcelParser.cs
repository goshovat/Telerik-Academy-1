namespace _06.ExcelParser
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class ExcelParser
    {
        public static void Main(string[] args)
        {
            var excelPath = "../../sample.xlsx";
            var excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            var connection = new OleDbConnection(string.Format(excelConnectionString, excelPath));
            var query = "SELECT * FROM [Sheet1$]";
            var command = new OleDbDataAdapter(query, connection);

            var dataSet = new DataSet();

            command.Fill(dataSet);

            var message = "Name: {0} - Score {1}";

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    var name = dr["Name"];
                    var score = dr["Score"];
                    Console.WriteLine(message, name, score);
                }
            }

            connection.Close();
        }
    }
}
