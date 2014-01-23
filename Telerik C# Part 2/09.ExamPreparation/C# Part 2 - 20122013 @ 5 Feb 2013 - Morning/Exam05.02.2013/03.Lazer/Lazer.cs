using System;
using System.Linq;

namespace _03.Lazer
{
    class Lazer
    {
        static int width;
        static int height;
        static int depth; 
        static int startWidth;
        static int startHeight;
        static int startDepth;
        static int directionWidth;
        static int directionHeight;
        static int directionDepth;
        static int currentW;
        static int currentH;
        static int currentD;


        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            width = int.Parse(dimensions[0]) + 1;
            height = int.Parse(dimensions[1]) + 1;
            depth = int.Parse(dimensions[2]) + 1;

            string[] positions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            startWidth = int.Parse(positions[0]);
            startHeight = int.Parse(positions[1]);
            startDepth = int.Parse(positions[2]);

            string[] directions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            directionWidth = int.Parse(directions[0]);
            directionHeight = int.Parse(directions[1]);
            directionDepth = int.Parse(directions[2]);

            MoveLazer();
        }

        private static void MoveLazer()
        {
            bool[, ,] cuboid = new bool[width, height, depth];

            cuboid[startWidth, startHeight, startDepth] = true;

            BurnTheEdges(cuboid);

            currentW = startWidth;
            currentH = startHeight;
            currentD = startDepth;

            while (true)
            {
                currentW += directionWidth;
                currentH += directionHeight;
                currentD += directionDepth;

                if (cuboid[currentW, currentH, currentD])
                {
                    currentW -= directionWidth;
                    currentH -= directionHeight;
                    currentD -= directionDepth;
                    break;
                }
                else if (CheckForWall())
                {
                    continue;
                }
                else
                {
                    cuboid[currentW, currentH, currentD] = true;
                }
            }

            Console.WriteLine("{0} {1} {2}", currentW, currentH, currentD);
        }


        private static void BurnTheEdges(bool[,,] cuboid)
        {
            for (int w = 1; w < width; w++)
            {
                cuboid[w, 1, 1] = true;
                cuboid[w, height - 1, 1] = true;
                cuboid[w, 1, depth - 1] = true;
                cuboid[w, height - 1, depth - 1] = true;
            }

            for (int d = 0; d < depth; d++)
            {
                cuboid[1, 1, d] = true;
                cuboid[width - 1, 1, d] = true;
                cuboid[1, height - 1, d] = true;
                cuboid[width - 1, height - 1, d] = true;
            }

            for (int h = 0; h < height; h++)
            {
                cuboid[1, h, 1] = true;
                cuboid[width - 1, h, 1] = true;
                cuboid[1, h, depth - 1] = true;
                cuboid[width - 1, h, depth - 1] = true;
            }
           
        }

        private static bool CheckForWall()
        {
            bool answer = false;

            if (currentW == 1 || currentW == width - 1) // Left or rightwall
            {
                directionWidth = -directionWidth;
                answer = true;
                return answer;
            }
            else if (currentD == 1 || currentD == depth - 1) // Front or back wall
            {
                directionDepth = -directionDepth;
                answer = true;
                return answer;
            }
            else if (currentH == 1 || currentH == height - 1) // Bottom or top wall
            {
                directionHeight = -directionHeight;
                answer = true;
                return answer;
            }
   
            return answer;
        }
    }
}