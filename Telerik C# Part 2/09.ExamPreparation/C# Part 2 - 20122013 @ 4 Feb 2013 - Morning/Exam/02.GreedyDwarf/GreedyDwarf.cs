using System;
using System.Numerics;

namespace _02.GreedyDwarf
{
    class GreedyDwarf
    {
        static void Main(string[] args)
        {
            char[] separator = {',', ' '};
            string[] valley = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int numberOfPatterns = int.Parse(Console.ReadLine());

            string[][] patterns = new string[numberOfPatterns][];

            for (int index = 0; index < numberOfPatterns; index++)
            {
                patterns[index] = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries); 
            }

            BigInteger maxCoins = int.MinValue;
            BigInteger currentCoins = int.MinValue;

            for (int index = 0; index < numberOfPatterns; index++)
            {
                currentCoins = GetCoins(valley, patterns[index]);
                if (currentCoins > maxCoins)
                {
                    maxCoins = currentCoins;
                }
            }

            Console.WriteLine(maxCoins);
        }

        private static BigInteger GetCoins(string[] valley, string[] pattern)
        {
            bool[] isPlaced = new bool[valley.Length];

            BigInteger coins = 0;
            int index = 0;
            int patternIndex = 0;
            
            while (true)
            {
                coins += int.Parse(valley[index]);
                isPlaced[index] = true;

                index += int.Parse(pattern[patternIndex]);
                patternIndex++;
                if (index > valley.Length - 1 || index < 0 || isPlaced[index] == true)
                {
                    break;
                }

                if (patternIndex == pattern.Length)
                {
                    patternIndex = 0;
                }
            }

            return coins;
        }
    }
}
