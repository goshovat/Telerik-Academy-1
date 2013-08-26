using System;
using System.IO;
using System.Text.RegularExpressions;

// Modify the solution of the previous problem to replace only whole words (not substrings).

class ReplaceWordInFile
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
                    output.WriteLine(Regex.Replace(line, @"\bstart\b", "finish")); 
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