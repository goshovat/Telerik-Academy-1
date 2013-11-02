namespace _02.IEnumerableTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
     
    public static class ExtensionMethod
    {
        public static T Sum<T>(this IEnumerable<T> numbers) where T : IComparable
        {
            dynamic sum = 0;

            foreach (var num in numbers)
            {
                sum += num;
            }

            return sum;
        }

        public static T Product<T>(this IEnumerable<T> numbers) where T : IComparable
        {
            dynamic product = 1;

            foreach (var num in numbers)
            {
                product *= num;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> numbers) where T : IComparable
        {
            dynamic min = numbers.FirstOrDefault(); 

            foreach (var num in numbers)
            {
                if (num < min)
                {
                    min = num;   
                }
            }

            return min;
        }


        public static T Max<T>(this IEnumerable<T> numbers) where T : IComparable
        {
            dynamic max = numbers.FirstOrDefault();

            foreach (var num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> numbers) where T : IComparable
        {
            dynamic sum = 0;
            dynamic numberCounter = 0;

            foreach (var item in numbers)
            {
                sum += item;
                numberCounter++;
            }

            return sum / numberCounter;
        }
    }

    class MethodsTest
    {

        static void Main(string[] args)
        {
            Console.Title = "Agregate methods";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Test with Integer:");

            Console.Write(new string('-', Console.WindowWidth));

            int[] intNumbers = new int[] { 1, 2, 4, 5, 3 };

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Sum = {0}", intNumbers.Sum());
            Console.WriteLine("Product = {0}", intNumbers.Product());
            Console.WriteLine("Max = {0}", intNumbers.Max());
            Console.WriteLine("Min = {0}", intNumbers.Min());
            Console.WriteLine("Average = {0}", intNumbers.Average());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Console.WriteLine("Test with Double:");
            Console.Write(new string('-', Console.WindowWidth));

            double[] doubleNumbers = new double[] {2.1, 1.2, 4.5, 3.2 };

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Sum = {0}", doubleNumbers.Sum());
            Console.WriteLine("Product = {0}", doubleNumbers.Product());
            Console.WriteLine("Max = {0}", doubleNumbers.Max());
            Console.WriteLine("Min = {0}", doubleNumbers.Min());
            Console.WriteLine("Average = {0}", doubleNumbers.Average());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string('-', Console.WindowWidth));

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
