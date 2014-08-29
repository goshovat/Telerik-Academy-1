namespace _01.SequenceOfNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceOfNumbersDemo
    {
        public static void Main(string[] args)
        {
            var numbers = GetInput();
            Console.WriteLine();
            Console.WriteLine("With LINQ sum = {0}", numbers.Sum(x => x));
            Console.WriteLine("With LINQ average = {0}", numbers.Average(x => x));

            Console.WriteLine();
            Console.WriteLine("The sum is = {0}", CalculateSum(numbers));
            Console.WriteLine("The average is = {0}", CalculateAverage(numbers));
        }

        private static IList<uint> GetInput()
        {
            var numbers = new List<uint>();
            var line = string.Empty;
            var number = 0u;

            Console.Write("Enter a number: ");
            line = Console.ReadLine();

            while (line != string.Empty)
            {
                if (uint.TryParse(line, out number))
                {
                    numbers.Add(number);
                }

                Console.Write("Enter a number: ");
                line = Console.ReadLine();
            }

            return numbers;
        }

        private static uint CalculateSum(IList<uint> numbers)
        {
            var sum = 0u;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        private static double CalculateAverage(IList<uint> numbers)
        {
            var sum = CalculateSum(numbers);
            var count = numbers.Count;
            var average = sum / (double)count;

            return average;
        }
    }
}
