using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MagicWords
{
    class MagicWords
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

            bool firstPosition = false;

            for (int i = 0; i < words.Count; i++)
            {
                int index = words[i].Length % (lines + 1);
                
                if (index != 0)
                {
                    if (firstPosition && index == 1)
                    {
                        
                    }
                    else
                    {
                        index--;
                    }
                    
                    if (words[index].Length == words[i].Length)
                    {
                        string temp = words[i];

                        words.RemoveAt(i);
                        words.Insert(index, temp);
                    }
                    else
                    {
                        if (index != i)
                        {
                            string temp = words[i];
                            words[i] = words[index];
                            words[index] = temp;
                        }
                    }
                }
                else 
                {
                    if (i != 0)
                    {
                        string temp = words[i];

                        for (int j = i; j >= 1; j--)
                        {
                            words[j] = words[j - 1];
                        }
                        words[0] = temp;
                        firstPosition = true;
                    }
                }             
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
