using System;
using System.IO;
using System.Text;

// Write a program that extracts from given XML file all the text without the tags.

class XMLFile
{
    static void Main(string[] args)
    {
        Console.Title = "XML file";

        StreamReader input = new StreamReader("XML.xml");

        string line;
        StringBuilder text = new StringBuilder();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("XML file contents:");
        Console.WriteLine(new string('-', 50));

        Console.ForegroundColor = ConsoleColor.Yellow;
        using (input)
        {
            line = input.ReadToEnd();
            Console.WriteLine(line);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 50));

        line = line.Replace("\r", "");
        line = line.Replace("\t", "");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe contents without tags:");
        Console.WriteLine(new string('-', 50));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i].Equals('>'))
            {
                i++;

                while (i != line.Length && !line[i].Equals('<'))
                {
                    text.Append(line[i]);
                    i++;
                }

                if (!text.ToString().Equals("\n"))
                {
                    Console.WriteLine(text);
                }
                
                text = new StringBuilder();
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 50));

        Console.ResetColor();
    }
}