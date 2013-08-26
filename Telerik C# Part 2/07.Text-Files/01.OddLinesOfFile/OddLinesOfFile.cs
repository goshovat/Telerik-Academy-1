using System;
using System.IO;


// Write a program that reads a text file and prints on the console its odd lines.

class OddLinesOfFile
{
    static void Main(string[] args)
    {
        Console.Title = "Print the odd lines from a file";

        try
        {
            StreamReader input = new StreamReader("Odd lines.txt"); // The file is in 07.Text-Files\01.OddLinesOfFile\bin\Debug

            using (input)
            {
                string readLine = input.ReadLine();
                int number = 1;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The odd lines of the file are:");
                Console.WriteLine(new string('-', 30));

                Console.ForegroundColor = ConsoleColor.Yellow;
                while (readLine != null)
                {
                    if (number % 2 == 1)
                    {
                        Console.WriteLine("{0}", readLine);
                    }
                    number++;
                    readLine = input.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string('-', 30));
            }
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The file was not found !!!");
        }
        finally
        {
            Console.ResetColor();
            Console.WriteLine();
        }
        
        
    }
}