using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _01._9GagNumbers
{
    class _9GagNumbers
    {            
        private static void GetNineGagFigures(string[] numbers)
        {
            numbers[0] = "-!";
            numbers[1] = "**";
            numbers[2] = "!!!";
            numbers[3] = "&&";
            numbers[4] = "&-";
            numbers[5] = "!-";
            numbers[6] = "*!!!";
            numbers[7] = "&*!";
            numbers[8] = "!!**!-";
        }

        private static ulong ConvertToDecimalNumber(string nineGagNumber, string[] numbers)
        {
            ulong decimalNumber = 0;

            StringBuilder number = new StringBuilder(nineGagNumber);

            List<ulong> coeficients = new List<ulong>();

            while (number.Length > 0)
            {
                for (int digit = 0; digit < numbers.Length; digit++)
                {
                    if (number.ToString().StartsWith(numbers[digit]))
                    {
                        coeficients.Add((ulong)digit);
                        number.Remove(0, numbers[digit].Length);
                    }
                }
            }

            int grade = 0;

            for (int i = coeficients.Count - 1; i >= 0; i--)
            {
                decimalNumber += GetPowNumber(grade) * coeficients[i];
                grade++;
            }

            return decimalNumber;
        }

        private static ulong GetPowNumber(int grade)
        {
            ulong powNumber = 1;
            for (int i = 1; i <= grade; i++)
            {
                powNumber *= 9;
            }

            return powNumber;
        }


        static void Main(string[] args)
        {
            var nineGagNumber = Console.ReadLine();

            string[] numbers = new string[9];

            GetNineGagFigures(numbers);

            Console.WriteLine(ConvertToDecimalNumber(nineGagNumber, numbers));
        }
    }
}
