namespace _09.MySqlConnector
{
    using System;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;

    public class MySqlConnector
    {
        public static void Main(string[] args)
        {
            // The database query to create the Library is in the project folder
            // Change uid and password to authorize access
            var server = "localhost";
            var database = "telerik_library";
            var uid = "telerik_user";
            var password = "telerik_user";
            var connectionString = string.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3};", server, database, uid, password);

            var connection = new MySqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                // Select all
                var books = SelectAllBooks(connection);

                var pattern = "Id: {0} \nTitle: {1} \nAuthor: {2} \nPublished date: {3} \nISBN: {4} \n{5}";
                var separator = new string('-', 60);

                Console.WriteLine("ALL BOOKS:");

                foreach (var book in books)
                {
                    Console.WriteLine(pattern, book.ID, book.Title, book.Author, book.PublishedDate, book.Isbn, separator);
                }

                Console.WriteLine();

                // Select book by name
                var searchedBook = SelectBookByTitle(connection, "Harry Potter");
                Console.WriteLine("SEARCHED BOOK:");
                Console.WriteLine(pattern, searchedBook.ID, searchedBook.Title, searchedBook.Author, searchedBook.PublishedDate, searchedBook.Isbn, separator);

                Console.WriteLine();

                // Insert book
                var insertMessage = "{0} row(s) affected";
                Console.WriteLine("INSERTED BOOK:");
                Console.WriteLine(insertMessage, InsertBook(connection, "Jack", "Gosho", DateTime.Now, "23456afsa"));

                Console.WriteLine();
            }
        }

        private static int InsertBook(MySqlConnection connection, string title, string author, DateTime publishedDate, string isbn)
        {
            string formatForMySql = publishedDate.ToString("yyyy-MM-dd HH:mm:ss");

            var query = "INSERT INTO books (title, author, published_date, isbn)" +
                "VALUES(@title, @author, @published_date, @isbn)";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@published_date", formatForMySql);
            cmd.Parameters.AddWithValue("@isbn", isbn);

            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected;
        }

        private static List<Book> SelectAllBooks(MySqlConnection connection)
        {
            var query = "SELECT * FROM books";

            var books = new List<Book>();

            var cmd = new MySqlCommand(query, connection);

            var dataReader = cmd.ExecuteReader();

            using (dataReader)
            {
                while (dataReader.Read())
                {
                    var date = dataReader.GetMySqlDateTime(3);
                    var datetime = DateTime.Parse(date.ToString());

                    int id = dataReader.GetInt32(0);
                    string title = dataReader.GetString(1);
                    var author = dataReader.GetString(2);
                    var isbn = dataReader.GetString(4);

                    books.Add(new Book(id, title, author, datetime, isbn));
                }
            }

            return books;
        }

        private static Book SelectBookByTitle(MySqlConnection connection, string searchedTitle)
        {
            var query = "SELECT * FROM books WHERE title = @title";

            Book book = null;

            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@title", searchedTitle);

            var dataReader = cmd.ExecuteReader();

            using (dataReader)
            {
                dataReader.Read();

                var date = dataReader.GetMySqlDateTime(3);
                var datetime = DateTime.Parse(date.ToString());
                var id = dataReader.GetInt32(0);
                var title = dataReader.GetString(1);
                var author = dataReader.GetString(2);
                var isbn = dataReader.GetString(4);

                book = new Book(id, title, author, datetime, isbn);
            }

            return book;
        }
    }
}
