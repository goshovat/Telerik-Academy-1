using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.DurankulakNumbers
{
    class DurankulakNumbers
    {
        private static void GetDurankulakFigures(string[] numbers)
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
            for (int i = 26; i < 168; i += 26)
            {
                letter = (char)(letter + 1);
                for (int j = 0; j < 26; j++)
                {
                    if (i + j == 168)
                    {
                        break;
                    }
                    numbers[i + j] = letter.ToString() + numbers[j];
                }
            }
        }

        private static BigInteger ConvertToDecimalNumber(string durankilakNumber, string[] numbers)
        {
            BigInteger decimalNumber = new BigInteger();

            int index = durankilakNumber.Length - 2;
            int grade = 0;

            while (true)
            {
                string figure;
                if (index >= 0)
                {
                    figure = durankilakNumber.Substring(index, 2);   
                }
                else if (index == - 1)
                {
                    figure = durankilakNumber.Substring(index + 1, 1); 
                }
                else
                {
                    break;
                }
                
                if (CheckFigure(figure, numbers))
                {
                    decimalNumber += (BigInteger)Math.Pow(168, grade) * FigureValue(figure, numbers);
                    index -= 2;
                }
                else
                {
                    decimalNumber += (BigInteger)Math.Pow(168, grade) * FigureValue(figure[1].ToString(), numbers);
                    index -= 1;
                }
                grade++;
            }

            return decimalNumber;
        }

        private static bool CheckFigure(string figure, string[] numbers)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                if (figure == numbers[index])
                {
                    return true;
                }
            }

            return false;
        }

        private static int FigureValue(string figure, string[] numbers)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                if (figure == numbers[index])
                {
                    return index;
                }
            }

            return 0;
        }

        static void Main(string[] args)
        {
            var durankulakNumber = Console.ReadLine();

            string[] numbers = new string[168];

            GetDurankulakFigures(numbers);

            Console.WriteLine(ConvertToDecimalNumber(durankulakNumber, numbers));
        }
    }
}
