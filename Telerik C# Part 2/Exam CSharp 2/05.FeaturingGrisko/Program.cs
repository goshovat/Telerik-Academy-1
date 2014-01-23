using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FeaturingGrisko
{
    class Program
    {
        private static int counter = 0;
        private static List<string> words = new List<string>();

        static void Permutate(char[] array, int start, int stop)
        {
            if (start == stop)
            {
                bool toAdd = true;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] == array[i + 1])
                    {
                        toAdd = false;
                    }
                }

                if (toAdd)
                {
                    string currentWord = new string(array);
                    bool isAdded = false;

                    if (words.Contains(currentWord))
                    {
                        isAdded = true;
                    }

                    if (!isAdded)
                    {
                        counter++;
                        words.Add(currentWord);
                    }

                }
            }
            else
            {
                for (int i = start; i < stop; i++)
                {
                    Swap(array, start, i);
                    Permutate(array, start + 1, stop);
                    Swap(array, start, i);
                }
            }
        }

        static void Swap(char[] array, int firstNumber, int secondNumber) // swap the number in the array
        {
            if (firstNumber == secondNumber)
            {
                return;
            }
            else
            {
                char temp = array[firstNumber];
                array[firstNumber] = array[secondNumber];
                array[secondNumber] = temp;
            }
        }


        static void Main(string[] args)
        {
            int numbers = 0;

            char[] letters = Console.ReadLine().ToCharArray();

            numbers = letters.Length;
            Permutate(letters, 0, numbers); // printing all the permutation
            Console.WriteLine(counter);
        }
    }
}