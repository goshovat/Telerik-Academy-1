using System;
using System.IO;

/*
    Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. 
    <html>
      <head><title>News</title></head>
      <body><p><a href="http://academy.telerik.com">Telerik
        Academy</a>aims to provide free real-world practical
        training for young people who want to turn into
        skillful .NET software engineers.</p></body>
    </html>
*/

class HTMLFile
{
    static void Main(string[] args)
    {
        Console.Title = "HTML file content";

        string text;

        StreamReader input = new StreamReader("Telerik.html");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("HTML file contents:");
        Console.Write(new string('-', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        using (input)
        {
            text = input.ReadToEnd();
            Console.WriteLine(text);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', Console.WindowWidth));

        int startIndex = text.IndexOf('<');
        int endIndex = text.IndexOf('>');
        while (startIndex != -1)
        {
            text = text.Remove(startIndex, endIndex - startIndex + 1);

            startIndex = text.IndexOf('<');
            endIndex = text.IndexOf('>');
        }

        text = text.Replace("\r", "");
        text = text.Replace("\t", "");
        text = text.Trim();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe contents without tags:");
        Console.Write(new string('-', Console.WindowWidth));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', Console.WindowWidth));

        Console.WriteLine();
        Console.ResetColor();
    }
}