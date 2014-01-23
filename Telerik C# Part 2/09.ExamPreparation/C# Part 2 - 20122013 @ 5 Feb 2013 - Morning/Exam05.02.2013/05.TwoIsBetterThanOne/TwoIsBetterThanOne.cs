using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _05.TwoIsBetterThanOne
{
    class TwoIsBetterThanOne
    {
        static void Main(string[] args)
        {
            string[] number = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long firstNumber = long.Parse(number[0]);
            long secondNunber = long.Parse(number[1]);

            string[] numbers = Console.ReadLine().Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            int percentage = int.Parse(Console.ReadLine());

            SolveFirstTask(firstNumber, secondNunber);

            SolveSecondTask(numbers, percentage);
        }


        private static void SolveFirstTask(long firstNumber, long secondNumber)
        {
            int counter = 0;
            long maxNumber = (long)Math.Pow(10, 18);
            List<long> palindroms = new List<long>();

            palindroms.Add(3);
           palindroms.Add(5);
            int i = 0;

            while (palindroms[palindroms.Count - 1] < secondNumber)
            {
                palindroms.Add(palindroms[i] * 10 + 3);
                palindroms.Add(palindroms[i] * 10 + 5);
                i++;
            }

            for (int index = 0; index < palindroms.Count; index++)
            {
                if (palindroms[index] < firstNumber)
                {
                    continue;
                }
                else if (palindroms[index] > secondNumber)
                {
                    break;
                }

                bool isPalindrom = true;
                string num = palindroms[index].ToString();
                for (int figure = 0; figure < num.Length / 2; figure++)
                {

                    if (num[figure] != num[num.Length - figure - 1])
                    {
                        isPalindrom = false;
                        break;
                    }
                    else if (num[figure] != '5' && num[figure] != '3')
                    {
                        isPalindrom = false;
                        break;
                    }
                }

                if (isPalindrom)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }

        private static void SolveSecondTask(string[] numbers, int percentage)
        {
            long[] nums = new long[numbers.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = long.Parse(numbers[i]);
            }

            Array.Sort(nums);

            double numberPercentage = nums.Length * percentage / 100.0;
            int index = (int)numberPercentage;
            
            if (index == numberPercentage && index > 0)
            {
                index--;
            }

            Console.WriteLine(nums[index]);
        }

    }
}
