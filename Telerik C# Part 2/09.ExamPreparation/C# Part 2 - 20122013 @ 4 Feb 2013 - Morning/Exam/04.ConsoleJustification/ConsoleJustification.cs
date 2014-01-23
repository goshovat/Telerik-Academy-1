using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace _04.ConsoleJustification
{
    class ConsoleJustification
    {
        static int indexOfWord = 0;

        static void Main(string[] args)
        {
            BigInteger linesNumber = BigInteger.Parse(Console.ReadLine());

            int characters = int.Parse(Console.ReadLine());

            List<string> words = new List<string>();

            for (int index = 0; index < linesNumber; index++)
            {
                words.AddRange(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            }

            do
            {
                AddLine(words, characters);
                indexOfWord++;
            } while (indexOfWord < words.Count);
        }

        private static void AddLine(List<string> words, int characters)
        {
            StringBuilder line = new StringBuilder();

            line.Append(words[indexOfWord]);

            while (line.Length < characters)
            {
                indexOfWord++;
                if (indexOfWord != words.Count)
                {
                    line.Append(' ');
                    line.Append(words[indexOfWord]);
                }
                else
                {
                    break;
                }
            }

            if (line.Length == characters)
            {
                Console.WriteLine(line);
            }
            else if (line.Length > characters)
            {
                line = line.Remove(line.ToString().LastIndexOf(' '), words[indexOfWord].Length + 1);
                indexOfWord--;
            }

            if (line[line.Length - 1] == ' ')
            {
                line.Remove(line.Length - 1, 1);
                Console.WriteLine(line);
                return;
            }

            if (line.Length < characters)
            {
                int indexOfWhiteSpace = line.ToString().IndexOf(' ');
                int whiteSpaces = 2;

                if (indexOfWhiteSpace != -1)
                {
                    while (line.Length < characters)
                    {
                        line.Insert(indexOfWhiteSpace, ' ');
                        indexOfWhiteSpace = line.ToString().IndexOf(' ', indexOfWhiteSpace + whiteSpaces);
                        if (indexOfWhiteSpace == -1)
                        {
                            whiteSpaces++;
                            indexOfWhiteSpace = line.ToString().IndexOf(' ');
                        }
                    }
                }
                Console.WriteLine(line);
            }
        }
    }
}