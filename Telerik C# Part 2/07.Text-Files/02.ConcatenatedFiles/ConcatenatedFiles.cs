using System;
using System.IO;

// Write a program that concatenates two text files into another text file.

class ConcatenatedFiles
{
    static void Main(string[] args)
    {
        Console.Title = "Concatenates two text files into another text file";

        // All files are in this foleder ----> 07.Text-Files\02.ConcatenatedFiles\bin\Debug

        StreamReader firstFile = new StreamReader("First file.txt");
        string firstFileContents;

        using (firstFile)
        {
            firstFileContents = firstFile.ReadToEnd();
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine("\"First file.txt\" contents:");
            Console.WriteLine(new string('-', 20));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(firstFileContents);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 20));
        }

        StreamReader secondFile = new StreamReader("Second file.txt");
        string secondFileContents;

        using (secondFile)
        {
            secondFileContents = secondFile.ReadToEnd();
            Console.WriteLine("\n\"First file.txt\" contents:");
            Console.WriteLine(new string('-', 20));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(secondFileContents);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 20));
        }

        StreamWriter thirdFile = new StreamWriter("Third file.txt", false);

        using (thirdFile)
        {
            thirdFile.WriteLine(firstFileContents);
            thirdFile.WriteLine(secondFileContents);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nThe info was saved to the third file!");
        }

        StreamReader output = new StreamReader("Third file.txt");
        string contents;

        using (output)
        {
            contents = output.ReadToEnd();
            Console.WriteLine("\n\"Third file.txt\" contents:");
            Console.WriteLine(new string('-', 20));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(contents);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('-', 20));
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}