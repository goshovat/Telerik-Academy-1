using System;
using System.Numerics;
using System.Text;

namespace _01.KaspichanNumbers
{
    class KaspichanNumbers
    {
        private static void GetKaspichanFigures(string[] numbers)
        {
            char letter = 'A';

            letter--;

            for (int i = 0; i < 26; i++)
            {
                letter = (char)(letter + 1);
                numbers[i] = letter.ToString();
            }

            letter = 'a';
            letter--;
            for (int i = 26; i < 256; i += 26)
            {
                letter = (char)(letter + 1);
                for (int j = 0; j < 26; j++)
                {
                    if (i + j == 256)
                    {
                        break;
                    }
                    numbers[i + j] = letter.ToString() + numbers[j];
                }
            }
        }

        private static string ConvertToKaspichanNumber(BigInteger decNumber, string[] numbers)
        {
            StringBuilder kaspichanNumber = new StringBuilder();

            do
            {
                kaspichanNumber.Insert(0, numbers[(int)(decNumber % 256)]);
                decNumber /= 256;
            } while (decNumber > 0);

            return kaspichanNumber.ToString();
        }

        static void Main(string[] args)
        {
            var decNumber = BigInteger.Parse(Console.ReadLine());

            string[] numbers = new string[256];

            GetKaspichanFigures(numbers);

            Console.WriteLine(ConvertToKaspichanNumber(decNumber, numbers));
        }
    }
}
