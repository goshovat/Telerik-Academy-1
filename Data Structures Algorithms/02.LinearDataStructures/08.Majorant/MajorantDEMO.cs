namespace _08.Majorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MajorantDemo
    {
        public static void Main(string[] args)
        {
            var numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            FindMajorant(numbers);

            numbers = new List<int>() { 2, 2, 3, 3};
            FindMajorant(numbers);
        }

        private static void FindMajorant(List<int> numbers)
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

            var majorantChecker = (numbers.Count / 2) + 1;
            var majorant = occuarances.Select(x => x).Where(x => x.Value >= majorantChecker);

            if (majorant.FirstOrDefault().Equals(default(KeyValuePair<int, int>)))
            {
                Console.WriteLine("No majorant");
            }
            else
            {
                Console.WriteLine("Majorant {0} -> {1} times of all {2}",
                    majorant.First().Key, majorant.First().Value, numbers.Count);
            }
        }
    }
}
