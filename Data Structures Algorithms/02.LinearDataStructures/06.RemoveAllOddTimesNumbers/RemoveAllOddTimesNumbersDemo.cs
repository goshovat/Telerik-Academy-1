namespace _06.RemoveAllOddTimesNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemoveAllOddTimesNumbersDemo
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            var result = RemoveAllOddTimesNumbers(numbers);
            Console.WriteLine(string.Join(", ", result));

            numbers = GetRandomNumbers(100000000);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            result = RemoveAllOddTimesNumbers(numbers);
            stopwatch.Stop();

           // Console.WriteLine(string.Join(", ", result));
            Console.WriteLine("Time: {0}", stopwatch.Elapsed);

        }

        private static List<int> GetRandomNumbers(int size)
        {
            var random = new Random();
            var numbers = new List<int>();

            for (int i = 0; i < size; i++)
            {
                numbers.Add(random.Next(100));
            }

            return numbers;
        }

        private static IEnumerable<int> RemoveAllOddTimesNumbers(List<int> numbers)
        {
            var counter = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (counter.ContainsKey(numbers[i]))
                {
                    counter[numbers[i]]++;
                }
                else
                {
                    counter.Add(numbers[i], 1);
                }
            }

            var result = numbers.Select(x => x).Where(x => counter[x] % 2 == 0);
            return result;
        }
    }
}
