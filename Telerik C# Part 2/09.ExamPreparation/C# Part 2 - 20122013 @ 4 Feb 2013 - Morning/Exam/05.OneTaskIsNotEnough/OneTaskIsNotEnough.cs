using System;
using System.Diagnostics;
using System.Linq;

namespace _05.OneTaskIsNotEnough
{
    class OneTaskIsNotEnough
    {
        static void Main(string[] args)
        {
            int lamps = int.Parse(Console.ReadLine());

            
             long ticksThisTime;

            string firstCommands = Console.ReadLine();
            string secondCommands = Console.ReadLine();
            Stopwatch timePerParse;
            timePerParse = Stopwatch.StartNew();
            SolveFirstTask(lamps);
            timePerParse.Stop();
            ticksThisTime = timePerParse.ElapsedTicks;
            Console.WriteLine(ticksThisTime + " 1");

            timePerParse = Stopwatch.StartNew();
            FindLastOpenedLamp(lamps);
            timePerParse.Stop();
            ticksThisTime = timePerParse.ElapsedTicks;
            Console.WriteLine(ticksThisTime + " 1");

            
            Console.WriteLine(SolveSecondTask(firstCommands));
            Console.WriteLine(SolveSecondTask(secondCommands));
        }

        private static int FindLastOpenedLamp(int numberOfLamps)
        {
            const int MaxLamps = 2000000;

            int lampsLeft = numberOfLamps;

            var lampsToTurnOn = new int[MaxLamps + 1];
            var lampsOff = new int[MaxLamps + 1];

            // Write all lamp numbers in numbers array
            // Initially all lamps are turned off
            for (int i = 1; i <= lampsLeft; i++)
            {
                lampsOff[i] = i;
            }

            int step = 0; // Every second, every third, ...
            while (lampsLeft > 1)
            {
                step++;

                // Find the lamps that will be turned on
                int currentIndex = 1;
                while (currentIndex <= lampsLeft)
                {
                    lampsToTurnOn[currentIndex] = step;
                    currentIndex += step + 1;
                }

                // Defragment lampsOff array
                int newCountOfLampsLeft = 0;
                for (int i = 1; i <= lampsLeft; i++)
                {
                    // The lamp is still off?
                    if (lampsToTurnOn[i] != step)
                    {
                        newCountOfLampsLeft++;
                        lampsOff[newCountOfLampsLeft] = lampsOff[i];
                    }
                }

                lampsLeft = newCountOfLampsLeft;
            }

            // Return the last lamp that is turned on
            return lampsOff[1];
        }

        private static void SolveFirstTask(long lamps)
        {
            int step = 2;
            int startLamp = 0;
            long lampsLeft = lamps;

            bool[] turnedOnLamps = new bool[lamps];

            while (lampsLeft != 1)
            {
                for (int index = startLamp; index < turnedOnLamps.Length; index++)
                {
                    if (!turnedOnLamps[index])
                    {
                        turnedOnLamps[index] = true;
                        lampsLeft--;
                        startLamp = index + 1;
                        break;
                    }
                }

                for (int index = startLamp, stepCounter = 0; index < turnedOnLamps.Length; index++)
                {
                    if (!turnedOnLamps[index])
                    {
                        stepCounter++;
                        if (stepCounter == step)
                        {
                            turnedOnLamps[index] = true;
                            lampsLeft--;
                            stepCounter = 0;
                        }
                    }
                }
                step++;
            }

            for (int index = turnedOnLamps.Length - 1; index > 0; index--)
            {
                if (!turnedOnLamps[index])
                {
                    Console.WriteLine(index + 1);
                    break;
                }
            }
        }


        private static string SolveSecondTask(string commands)
        {
            int[] movesX = { 1, 0, -1, 0 };
            int[] movesY = { 0, 1, 0, -1 };

            // Starting from (0,0)
            int currentX = 0, currentY = 0, direction = 0;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < commands.Length; j++)
                {
                    switch (commands[j])
                    {
                        case 'S':
                            currentX += movesX[direction];
                            currentY += movesY[direction];
                            break;
                        case 'L':
                            direction = (direction + 3) % 4; // +270 degrees, turns left
                            break;
                        case 'R':
                            direction = (direction + 1) % 4; // +90 degrees, turns right
                            break;
                    }
                }
            }

            if (currentX == 0 && currentY == 0)
            {
                // After 4 commands execution he is back on the starting place
                return "bounded";
            }
            else
            {
                // He moved after 4 commands execution
                // He will move again and again in the same direction after every next commands execution
                return "unbounded";
            }
        }

    }

}
