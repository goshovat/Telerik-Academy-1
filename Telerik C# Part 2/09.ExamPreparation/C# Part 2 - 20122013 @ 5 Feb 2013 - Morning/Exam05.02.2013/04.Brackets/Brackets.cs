using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Brackets
{
    class Brackets
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string symbols = Console.ReadLine();

            List<string> line = new List<string>();

            for (int index = 0; index < lines; index++)
            {
                line.Add(Console.ReadLine());
            }

            FormatCode(line, symbols);
        }

        private static void FormatCode(List<string> line, string symbols)
        {
          
            for (int index = 0; index < line.Count; index++)
            {
                string[] tempLines = line[index].Split(new char[]{'{'});

                if (tempLines.Length != 0)
                {
                    line[index] = tempLines[0];
                    for (int i = 1; i < tempLines.Length; i++)
                    {
                        index++;
                        line.Insert(index, "{");
                        index++;
                        line.Insert(index, tempLines[i]);
                    }
                }
            }

            for (int index = 0; index < line.Count; index++)
            {
                string[] tempLines = line[index].Split(new char[] { '}' });

                if (tempLines.Length != 0)
                {
                    line[index] = tempLines[0];
                    for (int i = 1; i < tempLines.Length; i++)
                    {
                        index++;
                        line.Insert(index, "}");
                        index++;
                        line.Insert(index, tempLines[i]);
                    }
                }
            }

            int bracketsNumber = 0;
            for (int index = 0; index < line.Count; index++)
            {
                line[index] = Regex.Replace(line[index], @"[\s]{2,}", " ");
                line[index] = Regex.Replace(line[index], @"[\t]{2,}", "");

              
                if (line[index].Length == 0 || (line[index][0] == ' ' && line[index].Length == 1))
                {
                    line.RemoveAt(index);
                    index--;
                    continue;
                }

                if (line[index].Contains('}'))
                {
                    bracketsNumber--;
                }

                if (line[index][0] == ' ')
                {
                    line[index] = line[index].Substring(1);
                }

                line[index] = String.Concat(Enumerable.Repeat(symbols, bracketsNumber)) + line[index];                

                if (line[index].Contains('{'))
                {
                    bracketsNumber++;
                }

                Console.WriteLine(line[index]);
            }
        }
    }
}
