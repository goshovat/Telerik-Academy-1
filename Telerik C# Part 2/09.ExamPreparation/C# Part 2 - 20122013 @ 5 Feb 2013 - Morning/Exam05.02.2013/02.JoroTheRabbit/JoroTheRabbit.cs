using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02.JoroTheRabbit
{
    class JoroTheRabbit
    {
         static void Main(string[] args)
        {
            char[] separator = {',', ' '};
            string[] terrainString = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int[] terrain = new int[terrainString.Length];

            for (int i = 0; i < terrain.Length; i++)
            {
                terrain[i] = int.Parse(terrainString[i]);
            }

            bool stop = false;

            int maxSteps = int.MinValue;
            int steps = 0;
            for (int startPosition = 0; startPosition < terrain.Length; startPosition++)
            {
                for (int step = 1; step < terrain.Length; step++)
                {
                    steps = GetSteps(terrain, step, startPosition);
                    
                    if (steps > maxSteps)
                    {
                        maxSteps = steps;

                        if (maxSteps == terrain.Length - 1)
                        {
                            maxSteps++;
                            stop = true;
                            break;
                        }
                    }
                }

                if (stop)
                {
                    break;
                }
            }

            Console.WriteLine(maxSteps);
        }

        private static int GetSteps(int[] terrain, int length, int startPosition)
        {
            int steps = 0;
            int index = startPosition;
            int lastIndex = 0;

            lastIndex = index;
            index += length;
            steps++;

            while (true)
            {
                if (index > terrain.Length - 1)
                {
                    index -= terrain.Length;
                }

                if (lastIndex > terrain.Length - 1)
                {
                    lastIndex -= terrain.Length;
                }

                if (startPosition == index || terrain[lastIndex] >= terrain[index])
                {
                    break;
                }
                else
                {
                    lastIndex = index;
                    index += length;
                    steps++;
                }
            }

            return steps;
        }
    }
}
