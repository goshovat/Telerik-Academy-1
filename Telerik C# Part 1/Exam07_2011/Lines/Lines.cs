using System;

class Lines
{
    static void Main(string[] args)
    {
        int[] arrayBytes = new int[8];
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

        int counter = 0;
        int maxtFullCells = 0;
        int line = 0;
       
        for (int row = 0; row < 8; row++)
        {
            counter = CountFullCells(bitsMatrix, row);
            if (maxtFullCells < counter)
            {
                maxtFullCells = counter;
            }
            counter = 0;
            counter = CountFullCellsColl(bitsMatrix, row);
            if (maxtFullCells < counter)
            {
                maxtFullCells = counter;
            }
            counter = 0;
        }

        if (maxtFullCells != 0)
        {
            for (int row = 0; row < 8; row++)
            {
                counter = CountFullCells(bitsMatrix, row);
                if (maxtFullCells == counter)
                {
                    line++;
                }
                counter = 0;
                counter = CountFullCellsColl(bitsMatrix, row);
                if (maxtFullCells == counter)
                {
                    line++;
                }
                counter = 0;
            }
            if (maxtFullCells == 1)
            {
                Console.WriteLine(maxtFullCells);
                Console.WriteLine(line / 2);
            }
            else
            {
              Console.WriteLine(maxtFullCells);
              Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine(0);
            Console.WriteLine(0);
        } 
    }

    static int CountFullCells(char[,] field, int i)
    {
        int fullCells = 0;
        int maxCells = 0;
        for (int j = 0; j < 8; j++)
        {
            if (field[i, j].Equals('1'))
            {
               
                fullCells++;
            }
            else
            {
                if (maxCells < fullCells)
                {
                    maxCells = fullCells;
                }
                fullCells = 0;
            }
        }
        if (fullCells == 1 && maxCells == 0)
        {
            return 1;
        }
        else if (fullCells > maxCells)
        {
            maxCells = fullCells;
        }
        return maxCells;
    }

    static int CountFullCellsColl(char[,] field, int i)
    {
        int fullCells = 0;
        int maxCells = 0;

        for (int j = 0; j < 8; j++)
        {
            if (field[j, i].Equals('1'))
            {
                fullCells++;
            }
            else
            {
                if (maxCells < fullCells)
                {
                    maxCells = fullCells;
                }
                fullCells = 0;
            }
        }
        if (fullCells == 1 && maxCells == 0)
        {
            return 1;
        }
        else if (fullCells > maxCells)
        {
            maxCells = fullCells;
        }
        return maxCells;
    }
}