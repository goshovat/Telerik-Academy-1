using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.OneTaskIsNotEnought
{
    //15:48
    class OneTaskIsNotEnough
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            
            string commands = Console.ReadLine();

            string secondCommands = Console.ReadLine();

            FirstTask(number);
            FindBoundedMoves(commands);
            FindBoundedMoves(secondCommands);

            
        }

        private static void FirstTask(int number)
        {
            List<int> lamps = new List<int>();
            List<int> notSwitchOn = new List<int>();

            for (int i = 1; i <= number; i++)
            {
                lamps.Add(i);
            }

            int step = 2;

            while (lamps.Count != 1)
            {
                int currentStep = 0;

                for (int i = 1; i < lamps.Count; i++)
                {
                    currentStep++;
                
                    if (currentStep != step)
                    {
                        notSwitchOn.Add(lamps[i]);                   
                    }
                    else
                    {
                        currentStep = 0;
                    }
                }

                lamps = notSwitchOn;
                notSwitchOn = new List<int>();
                step++;
            }
            Console.WriteLine(lamps[0]);
        }



        private static void FindBoundedMoves(string commands)
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
                Console.WriteLine("bounded");
            }
            else
            {
                // He moved after 4 commands execution
                // He will move again and again in the same direction after every next commands execution
                Console.WriteLine("unbounded");
            }
        }
    }
}
