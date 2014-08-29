namespace _07.Occuarances
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class OccuarancesDemo
    {
        public static void Main()
        {
            var numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var occuarances = FindOccurance(numbers);
            Console.WriteLine(occuarances);
        }

        private static string FindOccurance(List<int> numbers)
        {
            var occuarances = new SortedDictionary<int, int>();

            foreach (var number in numbers)
            {
                if (occuarances.ContainsKey(number))
                {
                    occuarances[number]++;
                }
                else
                {
                    occuarances[number] = 1;
                }
            }

            var builder = new StringBuilder();

            foreach (var occuarance in occuarances)
            {
                builder.AppendFormat("{0} -> {1} times\n", occuarance.Key, occuarance.Value);
            }

            return builder.ToString();
        }
    }
}
