using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<string> words = new List<string>();

            int maxLength = 0;

            for (int i = 0; i < lines; i++)
            {
                words.Add(Console.ReadLine());

                if (words[i].Length > maxLength)
                {
                    maxLength = words[i].Length;
                }
            }

            bool zero = false;

            for (int i = 0; i < lines; i++)
            {
                int index = words[i].Length % (lines + 1);

                if (index != 0)
                {
                    if (index == 1 && zero)
                    {

                    }
                    else
                    {
                        index--;
                    }
                }
                else
                {
                    zero = true;
                }
                string temp = words[i];
                words.RemoveAt(i);
                words.Insert(index, temp);
            }

            StringBuilder answer = new StringBuilder();

            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (i <= words[j].Length - 1)
                    {
                        answer.Append(words[j][i]);
                    }
                }
            }

            Console.WriteLine(answer);

        }
    }
}
