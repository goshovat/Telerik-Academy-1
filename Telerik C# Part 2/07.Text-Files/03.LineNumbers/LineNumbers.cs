using System;
using System.IO;
using System.Text;

// Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

class LineNumbers
{
    static void Main(string[] args)
    {
        Console.Title = "Line numbers";

        // Open the file where we will read data from
        StreamReader input = new StreamReader(@"..\..\LineNumbers.cs"); // File location "Project directory"

        using (input)
        {
            // Open the file where we will print the lines
            StreamWriter output = new StreamWriter("File.txt"); // File location "Project directory"\bin\Debug

            using (output)
            {
                string inputLine = input.ReadLine();
                int line = 1;
                StringBuilder outputLine;

                while (inputLine != null)
                {
                    // Inser a number in front of the line
                    outputLine = new StringBuilder();
                    outputLine.Append(line);
                    outputLine.Append(" ");
                    outputLine.Append(inputLine);

                    // Write the line to the file
                    output.WriteLine(outputLine);

                    // Read a new line
                    inputLine = input.ReadLine();
                    line++;
                }
            }
        }

        // Print the file with the numbers in fornt of each line
        StreamReader file = new StreamReader("File.txt");
        string contents;

        using (file)
        {
            contents = file.ReadToEnd();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\"File.txt\" contents:");
            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(contents);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        Console.ResetColor();
    }
}