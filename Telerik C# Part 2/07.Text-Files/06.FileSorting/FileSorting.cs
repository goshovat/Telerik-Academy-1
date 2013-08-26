using System;
using System.Collections.Generic;
using System.IO;

/*
    Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
	Ivan		    	George
	Peter	  --->		Ivan
	Maria		    	Maria
	George		    	Peter
*/

class FileSorting
{
    static void Main(string[] args)
    {
        Console.Title = "Sort the file contents";

        List<string> names = new List<string>();

        // Read the file
        StreamReader input = new StreamReader("Names.txt");

        using (input)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("The file contents:");
            Console.WriteLine(new string('-', 25));

            Console.ForegroundColor = ConsoleColor.Yellow;
            string line = input.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                names.Add(line);
                line = input.ReadLine();
            }
           
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('-', 25));
        }

        names.Sort(); // Sort the list

        // Write the sorted list to another file
        StreamWriter output = new StreamWriter("Sorted file.txt");

        using (output)
        {
            for (int i = 0; i < names.Count; i++)
            {
                output.WriteLine(names[i]);
            }
        }

        // Read the contents of the sorted file
        StreamReader sortedFile = new StreamReader("Sorted file.txt");

        using (sortedFile)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe sorted file contents:");
            Console.WriteLine(new string('-', 25));

            Console.ForegroundColor = ConsoleColor.Yellow;
            string line = sortedFile.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sortedFile.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 25));
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}