using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

/*
    Write a program that reads a list of words from a file words.txt and finds how many times
    each of the words is contained in another file test.txt. The result should be written in 
    the file result.txt and the words should be sorted by the number of their occurrences in 
    descending order. Handle all possible exceptions in your methods.
*/


class Words
{
    public static void Sort(List<string> words, List<int> times)
    {
        for (int i = 0; i < times.Count - 1; i++)
        {
            for (int j = i + 1; j < times.Count; j++)
            {
                if (times[i] < times[j])
                {
                    int temp = times[i];
                    times[i] = times[j];
                    times[j] = temp;

                    string tmp = words[i];
                    words[i] = words[j];
                    words[j] = tmp;
                }
            }
        }

    }

    static void Main(string[] args)
    {
        Console.Title = "Words in file";

        List<string> wordsToFind = new List<string>();
        List<int> times = new List<int>();

        try
        {
            // Get the word to delete
            StreamReader words = new StreamReader("words.txt");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nWords to remove: ");

            using (words)
            {
                string word = words.ReadLine();
                while (word != null)
                {
                    Console.Write("{0}, ", word);
                    wordsToFind.Add(word);
                    word = words.ReadLine();
                }
                Console.WriteLine();
            }

            Thread.Sleep(4000);
            
            // Get the file content
            StreamReader input = new StreamReader("test.txt");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe contents of the file:");
            Console.WriteLine(new string('-', 65));

            Console.ForegroundColor = ConsoleColor.Yellow;
            using (input)
            {
                string line = input.ReadToEnd();

                Console.WriteLine(line);

                for (int i = 0; i < wordsToFind.Count; i++)
                {
                    int counter = Regex.Matches(line, string.Format(@"\b{0}\b", wordsToFind[i])).Count;
                    times.Add(counter);
                }

                line = input.ReadLine();
            }

            Sort(wordsToFind, times);

            // Fill the result.txt
            StreamWriter output = new StreamWriter("result.txt");

            using (output)
            {
                for (int i = 0; i < wordsToFind.Count; i++)
                {
                    output.WriteLine("{0} - {1} times", wordsToFind[i], times[i]);           
                }
            }
             
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 65));

            Thread.Sleep(4000);

            // Read the new file
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe contents of the new file:");
            Console.WriteLine(new string('-', 65));
            input = new StreamReader("result.txt");

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
            Console.WriteLine(new string('-', 65));
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