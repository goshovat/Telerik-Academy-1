namespace _06.Divisor
{
    using System;
    using System.Linq;

    /*
        Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
        Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
    */

    public class Divisor
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Find all numbers that are divisible by 7 and 3 in an array:");

            int[] array = new int[150];

            for (int index = 1; index <= 150; index++)
            {
                array[index - 1] = index;
            }


            // USING EXTENSION METHODS
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n-Using lambda expressions");
            
            var divisibleFirstWay = array.ToList().FindAll(x => x % 21 == 0); // This will return a list

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   -=First way=-");
            Console.WriteLine(new string('-', 20));
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var number in divisibleFirstWay)
            {
                Console.WriteLine("\t{0}", number);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 20));
            
            Console.WriteLine();

            var divisibleSecondWay = array.Where(x => x % 21 == 0); // This will return an iterator

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   -=Second way=-");
            Console.WriteLine(new string('-', 20));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var number in divisibleSecondWay)
            {
                Console.WriteLine("\t{0}", number);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 20));

            // USING LINQ
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n-Using LINQ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 20));


            var result =
                from number in array
                where number % 21 == 0
                select number; // This will return again an iterator

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var number in divisibleSecondWay)
            {
                Console.WriteLine("\t{0}",number);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 20));


            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
