namespace _03.TransactionsHistory
{
    using _02.RetrieveingMoney;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    public class TransactionsHistory
    {
        public static void Main(string[] args)
        {
            CreateTransactionsHistoryTable();
            var cardNumber = "1234567891";
            var cardPIN = "1111";
            var withdraw = 1000;
            InsertData(cardNumber, cardPIN, withdraw);
        }

        public static int CountRecords()
        {
            var sqlConnectionString = "Server=.; Database=ATM; Integrated Security=true";

            var connection = new SqlConnection(sqlConnectionString);
            connection.Open();
            var count = 0;

            using (connection)
            {
                var query = "SELECT COUNT(*) FROM TransactionsHistory";
                var cmdCount = new SqlCommand(query, connection);
                count = (int)cmdCount.ExecuteScalar();
            }

            return count;
        }

        public static void InsertData(string cardNumber, string cardPIN, decimal withdraw)
        {
        

            if (RetrievingMoney.WithDraw(cardNumber, cardPIN, withdraw))
            {
                var sqlConnectionString = "Server=.; Database=ATM; Integrated Security=true";

                var connection = new SqlConnection(sqlConnectionString);
                connection.Open();

                using (connection)
                {
                    var transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                    Console.WriteLine("Transaction started.");
                    Console.WriteLine("Volatile data can be read but not modified during the transaction. New data can be added during the transaction.\n");

                    var command = connection.CreateCommand();
                    command.Transaction = transaction;

                    try
                    {
                        var query = "INSERT INTO TransactionsHistory(CardNumber, TransactionDate, Ammount) VALUES(@number, @date, @ammount)";

                        command.CommandText = query;
                        command.Parameters.AddWithValue("@number", cardNumber);
                        command.Parameters.AddWithValue("@date", DateTime.Now);

                        command.Parameters.AddWithValue("@ammount", withdraw);

                        var result = command.ExecuteNonQuery();

                        Console.WriteLine("Inserted new change");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Console.WriteLine();
                        Console.WriteLine("Transaction cancelled.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Cannot withdraw money!");
            }
        }

        private static void CreateTransactionsHistoryTable()
        {
            var path = "..\\..\\CreateHistory.sql";

            var script = File.ReadAllText(path);
            var queries = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

            var sqlConnectionString = "Server=.; Database=ATM; Integrated Security=true";

            var connection = new SqlConnection(sqlConnectionString);
            connection.Open();

            using (connection)
            {
                foreach (var query in queries)
                {
                    var cmdCount = new SqlCommand(query, connection);
                    var result = cmdCount.ExecuteNonQuery();
                }

                Console.WriteLine("The table TransactionsHistory was created!");
            }
        }
    }
}
