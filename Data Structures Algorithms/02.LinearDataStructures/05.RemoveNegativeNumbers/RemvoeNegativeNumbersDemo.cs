namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemvoeNegativeNumbersDemo
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>() { -1, -2, 2, -3, 3, -4, 4, 5, -5, 6 };

            // With LINQ
            var positiveNumbers = numbers.Select(x => x).Where(x => x >= 0).ToList();
            Console.WriteLine("With LINQ: {0}", string.Join(", ", positiveNumbers));

            Console.WriteLine();

            // Without LINQ
            positiveNumbers = GetPositiveNumbers(numbers);
            Console.WriteLine("Without LINQ: {0}", string.Join(", ", positiveNumbers));
        }

        private static List<int> GetPositiveNumbers(IList<int> numbers)
        {
            var positiveNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
            }

            return positiveNumbers;
        }
    }
}
