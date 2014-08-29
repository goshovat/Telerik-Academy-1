namespace _08.ExcelAppender
{
    using System.Data.OleDb;

    public class ExcelAppender
    {
        public static void Main(string[] args)
        {
            var excelPath = "../../sample.xlsx";
            var excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'; Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            using (var connection = new OleDbConnection(string.Format(excelConnectionString, excelPath)))
            {
                connection.Open();

                var query = "INSERT INTO [sheet1$](name, score) VALUES('Pesho', '150');";
                var command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
