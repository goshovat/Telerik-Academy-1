namespace _02.RetrieveingMoney
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class RetrievingMoney
    {
        private const string CONNECTION_STRING = "Server=.;" +
             " Database=ATM; Integrated Security=true";

        public static void Main(string[] args)
        {
            var cardNumber = "1234567891";
            var cardPIN = "1111";
            var withdraw = 1000;

            WithDraw(cardNumber, cardPIN, withdraw);
        }

        public static bool WithDraw(string cardNumber, string cardPIN = "1111", decimal withdraw = 10000)
        {
            var complete = true;

            //Change connection string if you you differant instance of SQL server
            var atmConnection = new SqlConnection(CONNECTION_STRING);

            atmConnection.Open();

            using (atmConnection)
            {

                var transaction = atmConnection.BeginTransaction(IsolationLevel.RepeatableRead);
                Console.WriteLine("Transaction started.");
                Console.WriteLine("Volatile data can be read but not modified during the transaction. New data can be added during the transaction.\n");

                var command = atmConnection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    var isAccountExists = CheckAccount(command, cardNumber, cardPIN);

                    if (!isAccountExists)
                    {
                        complete = false;
                        transaction.Rollback();
                        Console.WriteLine("Invalid account!");
                        Console.WriteLine("\nTransaction cancelled!");
                    }
                    else
                    {
                        Console.WriteLine("The account is valid");

                        var hasEnoughMoney = CheckBalance(command, cardNumber, cardPIN, withdraw);

                        if (!hasEnoughMoney)
                        {
                            complete = false;
                            transaction.Rollback();
                            Console.WriteLine("Not enough money!");
                            Console.WriteLine("\nTransaction cancelled!");
                        }
                        else
                        {
                            Console.WriteLine("The has enough money");

                            var paidComplate = Pay(command, cardNumber, cardPIN, withdraw);

                            if (!paidComplate)
                            {
                                complete = false;
                                transaction.Rollback();
                                Console.WriteLine("Error occurred while paying!");
                                Console.WriteLine("\nTransaction cancelled!");
                            }

                            Console.WriteLine("Paid complete");

                            transaction.Commit();
                            Console.WriteLine("\nTransaction comitted.");
                        }
                    }
                }
                catch (SqlException e)
                {
                    complete = false;
                    Console.WriteLine("Exception occured: {0}", e.Message);
                    transaction.Rollback();
                    Console.WriteLine("Transaction cancelled.");
                }

                return complete;
            }
        }

        public static decimal GetUserMoney(string cardNumber, string cardPIN)
        {
            var atmConnection = new SqlConnection(CONNECTION_STRING);
            var cardCash = 0m;

            atmConnection.Open();

            using (atmConnection)
            {
                var query= "SELECT CardCash FROM CardAccounts WHERE CardPIN = {0} AND CardNumber = {1}";

                var command = new SqlCommand( string.Format(query, cardPIN, cardNumber),atmConnection);

                cardCash = (decimal)command.ExecuteScalar();
            }

            return cardCash;
        }

        private static bool CheckAccount(SqlCommand command, string cardNumber, string cardPIN)
        {
            var query = "SELECT COUNT(*) FROM CardAccounts WHERE CardPIN = {0} AND CardNumber = {1}";


            command.CommandText = string.Format(query, cardPIN, cardNumber);
            var result = (int)command.ExecuteScalar();

            if (result == 0)
            {
                return false;
            }

            return true;
        }

        private static bool CheckBalance(SqlCommand command, string cardNumber, string cardPIN, decimal withdraw)
        {
            var result = GetUserMoney(cardNumber,cardPIN);

            if (result < withdraw)
            {
                return false;
            }

            return true;
        }

        private static bool Pay(SqlCommand command, string cardNumber, string cardPIN, decimal withdraw)
        {
            var query = "UPDATE CardAccounts " +
                " SET CardCash = CardCash - {0} " +
                " WHERE CardPIN = {1} AND CardNumber = {2}";

            command.CommandText = string.Format(query, withdraw, cardPIN, cardNumber);
            var result = (int)command.ExecuteNonQuery();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
