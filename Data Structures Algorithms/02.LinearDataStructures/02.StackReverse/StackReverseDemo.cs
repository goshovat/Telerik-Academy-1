namespace _02.StackReverse
{
    using System;
    using System.Collections.Generic;

    public class StackReverseDemo
    {
        public static void Main(string[] args)
        {
            var stopPoint = GetStopPoint();
            var numbers = GetNNumbers(stopPoint);
            Console.WriteLine("Numbers: {0}", string.Join(", ", numbers));

            var reversedNumbers = ReversNumbers(numbers);
            Console.WriteLine("Reversed numbers: {0}", string.Join(", ", reversedNumbers));
        }

        private static int GetStopPoint()
        {
            var stopPoint = -1;
            var line = string.Empty;

            while (stopPoint == -1)
            {
                Console.Write("How many numbers do you want: ");
                line = Console.ReadLine();

                if (int.TryParse(line, out stopPoint) && stopPoint > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a positive number!");
                }
            }

            return stopPoint;
        }

        private static IList<int> GetNNumbers(int stopPoint)
        {
            var numbers = new List<int>();
            var line = string.Empty;
            var number = 0;

            for (int i = 0; i < stopPoint; i++)
            {
                Console.Write("Please enter a number[{0}]: ", i + 1);
                line = Console.ReadLine();

                if (int.TryParse(line, out number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("Please enter a number!");
                    i--;
                }
            }

            return numbers;
        }

        private static IList<int> ReversNumbers(IList<int> numbers)
        {
            var stack = new Stack<int>();

            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            // The row below is an option, but I choose to do the "hard" thing :D
            // return stack.ToList<int>();
            var reversedNumbers = new List<int>();
            while (stack.Count != 0)
            {
                reversedNumbers.Add(stack.Pop());
            }
            
            return reversedNumbers;
        }
    }
}
