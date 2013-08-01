using System;

class Program
{
    static void Main(string[] args)
    {
        byte[] arrayBytes = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            arrayBytes[i] = byte.Parse(Console.ReadLine());    
        }

        char[,] bitsMatrix = new char[8, 8];
        
        for (int i = 0; i < 8; i++)
        {
            string number = Convert.ToString(arrayBytes[i], 2);
            if (number.Length % 8 != 0)
            {
                int length = number.Length % 8;
                number = new string('0', 8 - length) + number;
            }
            for (int j = 0; j < 8; j++)
            {
                bitsMatrix[i, j] = number[j];
            }
        }

        int leftFullCells = 0;
        int rightFullCells = 0;
        bool isPillar = false;        

        for (int pillar = 0; pillar < 8; pillar++)
        {
            leftFullCells = CountFullCells(0, pillar, bitsMatrix);
            rightFullCells = CountFullCells(pillar + 1, 8, bitsMatrix);

            if (leftFullCells == rightFullCells)
            {
                Console.WriteLine(7 - pillar);
                Console.WriteLine(leftFullCells);
                isPillar = true;
                break;
            }
        }

        if (!isPillar)
        {
            Console.WriteLine("No");
        }
    }

    static int CountFullCells(int start, int stop, char[,] field)
    {
        int fullCells = 0;
        for (int j = start; j < stop; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                if (field[i,j].Equals('1'))
                {
                    fullCells++;
                }
            }
        }
        return fullCells;
    }
}