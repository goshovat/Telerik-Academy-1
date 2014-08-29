namespace _09.MySqlConnector
{
    using System;

    public class Book
    {
        public Book(int iD, string title, string author, DateTime publishedDate, string isbn)
        {
            this.ID = iD;
            this.Title = title;
            this.Author = author;
            this.PublishedDate = publishedDate;
            this.Isbn = isbn;
        }

        public int ID { get; set; }
    
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Isbn { get; set; }
    }
}
