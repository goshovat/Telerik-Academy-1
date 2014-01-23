using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ThreeInOne
{
    class ThreeInOne
    {
        static void Main(string[] args)
        {
            string[] stringPoints = Console.ReadLine().Split(',');

            string[] cakes = Console.ReadLine().Split(',');
            int friends = int.Parse(Console.ReadLine());
            string[] numbers = Console.ReadLine().Split(' ');

            FirstTask(stringPoints);
            SecondTask(cakes, friends);
            ThirdTask(numbers);
        }

        private static void FirstTask(string[] stringPoints)
        {
            int[] points = new int[stringPoints.Length];

            int max = -1;
            int players = 0;
            int playerWinIndex = -1;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = int.Parse(stringPoints[i]);

                if (points[i] > max && points[i] <= 21)
                {
                    max = points[i];
                    players = 1;
                    playerWinIndex = i;
                }
                else if (points[i] == max)
                {
                    players++;
                    playerWinIndex = -1;
                }
            }

            Console.WriteLine(playerWinIndex);
        }


        private static void SecondTask(string[] cakes, int friends)
        {
            List<int> cakesSize = new List<int>();

            for (int i = 0; i < cakes.Length; i++)
            {
                cakesSize.Add(int.Parse(cakes[i]));
            }

            cakesSize.Sort();

            int bites = 0;

            while (cakesSize.Count != 0)
            {
                bites += cakesSize[cakesSize.Count - 1];
                cakesSize.RemoveAt(cakesSize.Count - 1);

                for (int i = 0; i < friends; i++)
                {
                    if (cakesSize.Count == 0)
                    {
                        break;
                    }

                    cakesSize.RemoveAt(cakesSize.Count - 1);
                }
            }

            Console.WriteLine(bites);
        }

        private static void ThirdTask(string[] numbers)
        {

            int G1 = int.Parse(numbers[0]);
            int S1 = int.Parse(numbers[1]);
            int B1 = int.Parse(numbers[2]);

            int G2 = int.Parse(numbers[3]);
            int S2 = int.Parse(numbers[4]);
            int B2 = int.Parse(numbers[5]);

            int exchangeOperations = 0;
            bool bronzeGet = false;


            while (B1 < B2)
            {
                bronzeGet = true;
                if (S1 <= S2)
                {
                    if (G1 <= G2)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                    else
                    {
                        G1--;
                        S1 += 9;
                        exchangeOperations++;
                        // if g1==0 return -1
                    }
                }
                else
                {
                    S1--;
                    B1 += 9;
                    exchangeOperations++;
                    // if s1==0 return -1
                }
            }

            while (S1 < S2)
            {
                if (bronzeGet)
                {
                    if (G1 <= G2)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                    else
                    {
                        G1--;
                        S1 += 9;
                        exchangeOperations++;
                        // if g1==0 return -1
                    }
                }
                else
                {
                    if (G1<= G2)
                    {
                        if (B1 - 11 < B2)
                        {
                            Console.WriteLine(-1);
                            return;    
                        }
                        else
                        {
                            B1 -= 11;
                            S1++;
                            exchangeOperations++;
                        }

                    }
                    else
                    {
                        G1--;
                        S1 += 9;
                        exchangeOperations++;
                        // if g1==0 return -1
                    }
                }
                
            }

            while (G1 < G2)
            {
                if (S1 - 11 < S2)
                {
                    if (B1 - 11 < B2)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                    else
                    {
                        B1 -= 11;
                        S1++;
                        exchangeOperations++;
                    }
                }
                else
                {
                    S1 -= 11;
                    G1++;
                    exchangeOperations++;
                }
            }

            if (G1 >= G2 && S1 >= S2 && B1 >= B2)
            {
                Console.WriteLine(exchangeOperations);    
            }
            else
            {
                Console.WriteLine(-1);
            }

        }

    }
}
