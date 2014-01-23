using System;
using System.Linq;

namespace _03.KukataIsDancing
{
    class KukataIsDancing
    {
       static int row = 1;
       static int col = 1;
       static int[,] array = new int[3, 3] {
                        { 1, 2, 1 },
                        { 2, 3, 2 },
                        { 1, 2, 1 }                    
            };

        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string[] directions = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                directions[i] = Console.ReadLine();
            }

            for (int i = 0; i < lines; i++)
            {
                row = 1;
                col = 1;
                Move(directions[i]);
            }
        }

        static void Move(string directions)
        {
            int tempRow = row;
            int temCol = col;

            for (int i = 0; i < directions.Length; i++)
			{
            }
            Console.WriteLine(GetColor());
        }

        private static string GetColor()
        {
            string color = "";

            switch (array[row, col])
            {
                case 1:
                    color = "RED";     ;
                    break;
                case 2:
                    color = "BLUE";
                    break;
                case 3:
                    color = "GREEN";
                    break;
            }

            return color;
        }
    }
}
