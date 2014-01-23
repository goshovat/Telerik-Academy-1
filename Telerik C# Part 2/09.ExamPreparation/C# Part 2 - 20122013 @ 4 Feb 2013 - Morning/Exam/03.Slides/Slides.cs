using System;

namespace _03.Slides
{
    class Slides
    {
        static int width;
        static int height;
        static int depth;

        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            width = int.Parse(dimensions[0]);
            height = int.Parse(dimensions[1]);
            depth = int.Parse(dimensions[2]);

            string[] separator = {" | "};

            string[][] widths = new string[height][];

            for (int index = 0; index < height; index++)
            {
                widths[index] = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }

            dimensions = Console.ReadLine().Split(' ');
            int ballW = int.Parse(dimensions[0]);
            int ballD = int.Parse(dimensions[1]);
            int ballH = 0;

            while (true)
            {
                GoToPosition(ref ballW, ref ballH, ref ballD, widths[ballH][ballD]); 
            }
        }

        private static void GoToPosition(ref int ballW, ref int ballH, ref int ballD, string depthWidth)
        {
            string[] widths = depthWidth.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            int currentW = ballW;
            int currentD = ballD;
            int currentH = ballH;

            switch (widths[ballW][0])
            {
                case 'S':
                    switch (widths[ballW].Substring(2))
                    {
                        case "B":
                            ballD++;
                            ballH++;
                            break;
                        case "F":
                            ballD--;
                            ballH++;
                            break;
                        case "L":
                            ballW--;
                            ballH++;
                            break;
                        case "R":
                            ballW++;
                            ballH++;
                            break;
                        case "BL":
                            ballW--;
                            ballD++;
                            ballH++;
                            break;
                        case "BR":
                            ballW++;
                            ballD++;
                            ballH++;
                            break;
                        case "FL":
                            ballW--;
                            ballD--;
                            ballH++;
                            break;
                        case "FR":
                            ballW++;
                            ballD--;
                            ballH++;
                            break;
                    }
                    break;
                case 'T':
                    string[] numbers = widths[ballW].Split(' ');
                    ballW = int.Parse(numbers[1]);
                    ballD = int.Parse(numbers[2]);
                    break;
                case 'E':
                    ballH++;
                    break;
                case 'B':
                    Console.WriteLine("No");
                    Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
                    Environment.Exit(0);
                    break;
            }

            if (ballH == height)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", currentW, currentH, currentD);
                Environment.Exit(0);
            }
            else
            { 
                if (ballW == width || ballW == -1 || ballD == depth || ballD == -1)
                {
                    Console.WriteLine("No");
                    Console.WriteLine("{0} {1} {2}", currentW, currentH, currentD);
                    Environment.Exit(0);
                }
            }
        }
    }
}
