namespace SortPerformance
{
    using System;
    using System.Linq;
    using System.Text;

    internal class Demo
    {
        private static readonly char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'h', 'i', 'j' };
        private static readonly Random generator = new Random();

        private static void RandomizeArrays(int[] randomInt, double[] randomDouble, string[] randomString)
        {
            for (int i = 0; i < randomInt.Length; i++)
            {
                randomInt[i] = generator.Next();
            }

            for (int i = 0; i < randomDouble.Length; i++)
            {
                randomDouble[i] = generator.NextDouble();
            }

            for (int i = 0; i < randomString.Length; i++)
            {
                int stringLength = generator.Next(10) + 1;
                StringBuilder builder = new StringBuilder();

                for (int j = 0; j < stringLength; j++)
                {
                    builder.Append(letters[generator.Next(9)]);
                }

                randomString[i] = builder.ToString();
            }
        }

        public static void Main(string[] args)
        {
            SortAlgorithm[] sortAlgorithms = new SortAlgorithm[] { new QuickSort(), new SelectionSort(), new InsertionSort() };
            
            // Unsorted elements
            int arrayLength = 7000;
            int[] randomInt = new int[arrayLength];
            double[] randomDouble = new double[arrayLength];
            string[] randomString = new string[arrayLength];

            RandomizeArrays(randomInt, randomDouble, randomString);
           

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Unsorted arrays:");

            foreach (var sortAlgorithm in sortAlgorithms)
            {
                sortAlgorithm.MeasureInt(randomInt);
                RandomizeArrays(randomInt, randomDouble, randomString);

                sortAlgorithm.MeasureDouble(randomDouble);
                RandomizeArrays(randomInt, randomDouble, randomString);

                sortAlgorithm.MeasureString(randomString);
                RandomizeArrays(randomInt, randomDouble, randomString);

                Console.WriteLine();
            }

            // Sorted elements
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Sorted arrays:");

            foreach (var sortAlgorithm in sortAlgorithms)
            {
                sortAlgorithm.MeasureInt(randomInt);
                sortAlgorithm.MeasureDouble(randomDouble);
                sortAlgorithm.MeasureString(randomString);

                Console.WriteLine();
            }

            // Reversed elements
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Reversed arrays:");

            foreach (var sortAlgorithm in sortAlgorithms)
            {
                Array.Reverse(randomInt);
                Array.Reverse(randomDouble);
                Array.Reverse(randomString);

                sortAlgorithm.MeasureInt(randomInt);
                sortAlgorithm.MeasureDouble(randomDouble);
                sortAlgorithm.MeasureString(randomString);

                Console.WriteLine();
            }
        }
    }
}
