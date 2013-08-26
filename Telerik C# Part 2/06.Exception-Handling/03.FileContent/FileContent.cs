using System;
using System.IO;
using System.Security;
/*
    Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
    reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
    Be sure to catch all possible exceptions and print user-friendly error messages.
*/

class FileContent
{
    static void Main(string[] args)
    {
        Console.Title = "File content";

        //Console.Write("Enter the full file path: ");  
        //string path = Console.ReadLine();
        string path = @"..\..\TestDocument.txt"; // The document is in the project's folder

        try
        {
            string content = File.ReadAllText(path);

            // The file was read successfully and the program will print the contents
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The contents of the file \"{0}\" :", path.Substring(path.LastIndexOf("\\") + 1));
            Console.WriteLine(new string('-', 50));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(content);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 50));
        }
        catch (PathTooLongException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The path is too long");
        }
        catch (DirectoryNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("One of directories is missing");
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The file was not found !!!");
        }
        catch (IOException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The error with input / output !!!");
        }
        catch (SecurityException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The error with security !!!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The access to the file is denied !!!");
        }
        catch (ArgumentNullException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The path has null value !!!");
        }
        catch (ArgumentException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have entered a wrong path !!!");
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("FATAL ERROR !!!");
        }
        finally
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nGood bye!\n");
        }

        Console.ResetColor();
        Console.WriteLine();
    }
}