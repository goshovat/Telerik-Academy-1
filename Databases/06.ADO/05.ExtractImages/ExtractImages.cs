namespace _05.ExtractImages
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public class ExtractImages
    {
        public static void Main(string[] args)
        {
            var pictures = ExtractAllPictures();
            WriteBinaryFile(pictures);

            var message = "The pictures are in the project's folder";
            Console.WriteLine(message);
        }

        private static Dictionary<string, byte[]> ExtractAllPictures()
        {
            var pictures = new Dictionary<string, byte[]>();

            var sqlConnectionString = "Server=.\\; Database=NorthWind; Integrated Security=true";

            var dbConn = new SqlConnection(sqlConnectionString);
            dbConn.Open();

            using (dbConn)
            {
                var query = "SELECT CategoryName, Picture FROM Categories";

                var cmd = new SqlCommand(query, dbConn);

                var reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        pictures[(string)reader["CategoryName"]] = (byte[])reader["Picture"];
                    }
                }
            }

            return pictures;
        }

        private static void WriteBinaryFile(Dictionary<string, byte[]> pictures)
        {
            var path = "../../{0}.JPG";

            foreach (var picture in pictures)
            {
                int header = 78;
                byte[] imgData = new byte[picture.Value.Length - header];
                Array.Copy(picture.Value, 78, imgData, 0, picture.Value.Length - header);

                var memoryStream = new MemoryStream(imgData);
                var image = Image.FromStream(memoryStream);
                image.Save(new FileStream(string.Format(path, picture.Key.Replace("/", "-")), FileMode.Create), ImageFormat.Jpeg);
            }
        }
    }
}
