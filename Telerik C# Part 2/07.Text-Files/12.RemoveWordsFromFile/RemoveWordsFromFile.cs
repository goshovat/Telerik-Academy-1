using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

// Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

class RemoveWordsFromFile
{
    static void Main(string[] args)
    {
        Console.Title = "Remove given words from a file";

        List<string> wordsToRemove = new List<string>();

        try
        {
            // Get the words to delete
            StreamReader words = new StreamReader("Words.txt");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWords to remove: ");

            using (words)
            {
                string word = words.ReadLine();
                while (word != null)
                {
                    Console.Write("{0}, ", word);
                    wordsToRemove.Add(word);
                    word = words.ReadLine();
                }
                Console.WriteLine();
            }

            Thread.Sleep(4000);

            // Get the file content and remove words
            StreamReader input = new StreamReader("File.txt");
            StreamWriter output = new StreamWriter("File without words.txt");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe contents of the file:");
            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.ForegroundColor = ConsoleColor.Yellow;
            using (input)
            {
                using (output)
                {
                    string line = input.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        for (int i = 0; i < wordsToRemove.Count; i++)
                        {
                            line = Regex.Replace(line, string.Format(@"\b{0}\b", wordsToRemove[i]), String.Empty);
                        }
                        output.WriteLine(line);
                        line = input.ReadLine();
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', Console.WindowWidth));

            Thread.Sleep(5000);

            // Read the new file
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe contents of the new file:");
            Console.WriteLine(new string('-', Console.WindowWidth));
            input = new StreamReader("File without words.txt");

            Console.ForegroundColor = ConsoleColor.Yellow;
            using (input)
            {
                string line = input.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = input.ReadLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', Console.WindowWidth));
        }
        catch (ArgumentNullException)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Null reference is passed to a method !!!");
        }
        catch (ArgumentException)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Some of the arguments are invalid !!!");
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The file can't be found !!!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The path is incorrect !!!");
        }
        catch (IOException)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Error with the streams !!!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Can't access the file !!!");
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
            Console.ResetColor();
        }
    }
}