namespace _01.OccurrencesCounter
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
    /// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
    /// -2.5 -> 2 times
    /// 3 -> 4 times
    /// 4 -> 3 times
    /// </summary>
    public class OccurrencesCounter
    {
        public static void Main(string[] args)
        {
            var elements = new double[]{3, 4, 4, -2.5, 3, 3, 4, 3, -2.5};

            var occurrences = CountOccurrences(elements);
            var pattern = "{0} -> {1} times";
            foreach (var occurrence in occurrences)
            {
                Console.WriteLine(pattern, occurrence.Key, occurrence.Value);
            }
        }

        private static Dictionary<double, int> CountOccurrences(double[] elements)
        {
            var occurrences = new Dictionary<double, int>();

            foreach (var item in elements)
            {
                if (!occurrences.ContainsKey(item))
                {
                    occurrences[item] = 0;
                }

                occurrences[item]++;
            }

            return occurrences;
        }
    }
}
