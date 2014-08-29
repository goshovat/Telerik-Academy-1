namespace _04.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogestSubsequence
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 2, 3, 3, 4, 5, 5 };
            var longestSequences = FindAllLongestSubsequences(numbers);

            foreach (var sequence in longestSequences)
            {
                Console.WriteLine("Longest sequence: {0}", string.Join(", ", sequence));
            }

            Console.WriteLine();

            numbers = new List<int>() { 1, 2, 3, 4, 5, 2 };
            longestSequences = FindAllLongestSubsequences(numbers);

            foreach (var sequence in longestSequences)
            {
                Console.WriteLine("Longest sequence: {0}", string.Join(", ", sequence));
            }

            Console.WriteLine();

            numbers = new List<int>() { 1, 2, 2, 3, 4, 4, 4, 5, 5, 2 };
            longestSequences = FindAllLongestSubsequences(numbers);

            foreach (var sequence in longestSequences)
            {
                Console.WriteLine("Longest sequence: {0}", string.Join(", ", sequence));
            }
        }

        private static List<List<int>> FindAllLongestSubsequences(List<int> numbers)
        {
            var longestSequences = new List<List<int>>();
            var maxLength = GetLongestEqualSequenceLength(numbers);
            var length = 1;
            var sequence = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                sequence.Add(numbers[i]);

                if (numbers[i] == numbers[i + 1])
                {
                    length++;
                }
                else
                {
                    if (maxLength == length)
                    {
                        longestSequences.Add(sequence);
                    }

                    sequence = new List<int>();
                    length = 1;
                }
            }

            sequence.Add(numbers[numbers.Count - 1]);

            if (sequence.Count == maxLength)
            {
                longestSequences.Add(sequence);
            }

            return longestSequences;
        }

        private static int GetLongestEqualSequenceLength(List<int> numbers)
        {
            var maxLength = 1;
            var counter = 1;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                }
                else
                {
                    if (maxLength < counter)
                    {
                        maxLength = counter;
                    }

                    counter = 1;
                }
            }

            return maxLength;
        }
    }
}
