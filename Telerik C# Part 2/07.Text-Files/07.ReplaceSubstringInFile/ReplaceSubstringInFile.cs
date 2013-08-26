using System;
using System.IO;

/*
    Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a 
    text file. Ensure it will work with large files (e.g. 100 MB).
*/
class ReplaceSubstringInFile
{
    static void Main(string[] args)
    {
        Console.Title = "Repace substring in file";

        StreamReader input = new StreamReader("Replace.txt");
        StreamWriter output = new StreamWriter("File.txt", false);

        // Read a line, replace "start" with "finish" and write it to the file
        using (input)
        {
            using (output)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The file contents:");
                Console.WriteLine(new string('-', 45));

                string line = input.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                while (line != null)
                {
                    Console.WriteLine(line);
                    output.WriteLine(line.Replace("start", "finish"));
                    line = input.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string('-', 45));
            }
        }

        // Read the replaced file
        StreamReader replacedFile = new StreamReader("File.txt");

        using (replacedFile)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe replaced file contents:");
            Console.WriteLine(new string('-', 45));

            Console.ForegroundColor = ConsoleColor.Yellow;
            string line = replacedFile.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = replacedFile.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 45));
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}