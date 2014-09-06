namespace _02.OddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that extracts from a given sequence of strings all elements that 
    /// present in it odd number of times. Example:
    /// {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
    /// </summary>
    public class OddOccurences
    {
        public static void Main(string[] args)
        {
            var elements = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var oddOccurrenceElements = FindOddOccurrencesElements(elements);

            foreach (var element in oddOccurrenceElements)
            {
                Console.WriteLine(element);
            }
        }

        private static IEnumerable<string> FindOddOccurrencesElements(string[] elements)
        {
            var occurrences = new Dictionary<string, int>();

            foreach (var item in elements)
            {
                if (!occurrences.ContainsKey(item))
                {
                    occurrences[item] = 0;
                }

                occurrences[item]++;
            }

            var oddOccurrences = occurrences.Where(o => o.Value % 2 != 0).Select(o => o.Key);

            return oddOccurrences;
        }
    }
}
