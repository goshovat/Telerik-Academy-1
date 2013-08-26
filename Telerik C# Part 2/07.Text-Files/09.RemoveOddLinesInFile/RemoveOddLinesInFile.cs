using System;
using System.Collections.Generic;
using System.IO;

// Write a program that deletes from given text file all odd lines. The result should be in the same file.

class RemoveOddLinesInFile
{
    public static void PrintContents()
    {
        StreamReader changedFile = new StreamReader("File.txt");

        using (changedFile)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 45));

            string line = changedFile.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            while (line != null)
            {
                Console.WriteLine(line);
                line = changedFile.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 45));
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Remove odd lines in the file";

        /*
            There is a file "THE COPY OF ORIGINAL FILE CONTENTS.txt"  in "..\07.Text-Files\09.RemoveOddLinesInFile\bin\Debug",
            where are the original contents of the "File.txt" if you want to see or copy it again
        */

        // Print the file contents
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe original file contents:");
        PrintContents();

        List<string> evenLines = new List<string>();

        StreamReader input = new StreamReader("File.txt");

        // Save the even lines of the file
        using (input)
        {
            string line = input.ReadLine();
            int row = 1;

            while (line != null)
            {
                if ((row & 1) == 0) // Even line
                {
                    evenLines.Add(line);
                }

                line = input.ReadLine();
                row++;
            }
        }

        StreamWriter output = new StreamWriter("File.txt");

        // Write the even lines to the file
        using (output)
        {
            for (int i = 0; i < evenLines.Count; i++)
            {
                output.WriteLine(evenLines[i]);
            }
        }

        System.Threading.Thread.Sleep(2000);

        // Print the file contents
        Console.WriteLine("\nThe changed file contents:");
        PrintContents();

        Console.WriteLine();
        Console.ResetColor();
    }
}