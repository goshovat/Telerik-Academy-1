namespace _03.SortingNumbers
{
    using System;
    using System.Collections.Generic;

    public class SortingNumbersDemo
    {
        public static void Main(string[] args)
        {
            var numbers = GetInput();
            Console.WriteLine("Numbers: {0}", string.Join(", ", numbers));

            // SortEasy(numbers);
            SelectionSort(numbers);
            Console.WriteLine("Sorted numbers: {0}", string.Join(", ", numbers));
        }

        private static IList<int> GetInput()
        {
            var numbers = new List<int>();
            var line = string.Empty;
            var number = 0;

            Console.Write("Enter a number: ");
            line = Console.ReadLine();

            while (line != string.Empty)
            {
                if (int.TryParse(line, out number))
                {
                    numbers.Add(number);
                }

                Console.Write("Enter a number: ");
                line = Console.ReadLine();
            }

            return numbers;
        }

        private static void SortEasy(IList<int> numbers)
        {
            var sortedNumbers = numbers as List<int>;
            sortedNumbers.Sort();
        }

        private static void SelectionSort(IList<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var minElement = int.MaxValue;
                var index = -1;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (minElement > numbers[j])
                    {
                        minElement = numbers[j];
                        index = j;
                    }
                }

                if (minElement < numbers[i])
                {
                    numbers[i] = numbers[i] + numbers[index];
                    numbers[index] = numbers[i] - numbers[index];
                    numbers[i] = numbers[i] - numbers[index];
                }
            }
        }
    }
}
