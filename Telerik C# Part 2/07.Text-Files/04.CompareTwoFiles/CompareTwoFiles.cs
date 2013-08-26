using System;
using System.IO;

/*
    Write a program that compares two text files line by line and prints the number of lines 
    that are the same and the number of lines that are different. Assume the files have equal number of lines.
*/

class CompareTwoFiles
{
    static void Main(string[] args)
    {
        Console.Title = "Compare two files line by line";

        // Open the first file
        StreamReader firstFile = new StreamReader("First file.txt"); // File location ..\07.Text-Files\04.CompareTwoFiles\bin\Debug

        using (firstFile)
        {
            // Open the second file
            StreamReader secondFile = new StreamReader("Second file.txt"); //File location ..\07.Text-Files\04.CompareTwoFiles\bin\Debug

            using (secondFile)
            {
                int equalLines = 0;
                int differentLines = 0;

                // Read the first line of each files
                string firstFileLine = firstFile.ReadLine();
                string secondFileLine = secondFile.ReadLine();            

                while (firstFileLine != null && secondFileLine != null)
                {
                    // Print the two read lines
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("First file line  ---> {0}", firstFileLine);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Second file line ---> {0}", secondFileLine);

                    // Check if the lines are equal
                    if (firstFileLine.Equals(secondFileLine))
                    {
                        equalLines++;
                        Console.WriteLine();
                    }
                    else
                    {
                        differentLines++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" <--- DIFFERENCE");
                    }

                    // Read another line
                    firstFileLine = firstFile.ReadLine();
                    secondFileLine = secondFile.ReadLine();
                }

                // Print the numbers of equal and different lines
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThe two files has {0} equal lines and {1} different lines.", equalLines, differentLines);
            }
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}