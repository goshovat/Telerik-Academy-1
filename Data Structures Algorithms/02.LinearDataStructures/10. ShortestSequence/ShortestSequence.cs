namespace _10.ShortestSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestSequence
    {
        public static void Main(string[] args)
        {
            var fromNumber = 5;
            var toNumber = 18;
            
            Console.WriteLine("Shortest path to from number {0} to number {1} is: \n{2}",
                fromNumber, toNumber, FindShortestSequence(fromNumber, toNumber));
        }

        private static string FindShortestSequence(int startNumber, int searchedNumber)
        {
            var sequences = new Queue<Sequence>();
            var shortestPath = string.Empty;
            var hasFound = false;

            sequences.Enqueue(new Sequence(startNumber, startNumber.ToString()));

            if (startNumber == searchedNumber)
            {
                shortestPath = string.Format("{0} -> {1}", startNumber, searchedNumber);
            }
            else
            {
                while (!hasFound)
                {
                    var first = sequences.Dequeue();
                    var second = first;
                    var third = first;

                    first.LastNumber = first.LastNumber + 1;
                    first.Path = string.Format("{0} -> {1}", first.Path, first.LastNumber);

                    if (first.LastNumber == searchedNumber)
                    {
                        hasFound = true;
                        shortestPath = first.Path;
                    }

                    sequences.Enqueue(first);

                    second.LastNumber = second.LastNumber + 2;
                    second.Path = string.Format("{0} -> {1}", second.Path, second.LastNumber);

                    if (second.LastNumber == searchedNumber)
                    {
                        hasFound = true;
                        shortestPath = second.Path;
                    }

                    sequences.Enqueue(second);

                    third.LastNumber = third.LastNumber * 2;
                    third.Path = string.Format("{0} -> {1}", third.Path, third.LastNumber);

                    if (third.LastNumber == searchedNumber)
                    {
                        hasFound = true;
                        shortestPath = third.Path;
                    }

                    sequences.Enqueue(third);
                }
            }

            return shortestPath;
        }

        internal struct Sequence
        {
            internal int LastNumber;

            internal string Path;

            internal Sequence(int lastNumber, string numbers)
            {
                this.LastNumber = lastNumber;
                this.Path = numbers;
            }
        }
    }
}
