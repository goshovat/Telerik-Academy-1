using System;

class FallDown
{
    static void Main(string[] args)
    {
        byte[] arrayBytes = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            arrayBytes[i] = byte.Parse(Console.ReadLine());
        }

        char[,] bitsMatrix = new char[8, 8];
        char[,] newMatrix = new char[8, 8];
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

        for (int j = 0; j < 8; j++)
        {
            counter = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bitsMatrix[i, j].Equals('1'))
                {
                    counter++;
                }
            }
            if (counter != 0)
            {
                newMatrix = Fall(counter, 8, j, newMatrix);
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (!newMatrix[i, j].Equals('1'))
                {
                    newMatrix[i, j] = '0';
                }
            }
        }


        string newNumber = "";
        for (int i = 0; i < 8; i++)
        {
            newNumber = "";
            for (int j = 0; j < 8; j++)
            {
                newNumber += newMatrix[i, j];
            }
            Console.WriteLine(Convert.ToUInt64(newNumber, 2));
        }

    }

    static char[,] Fall(int counter, int size, int coll, char [,] field)
    {
        do
        {
            size--;
            field[size, coll] = '1';
            counter--;
        } while (counter > 0);
        return field;
    }
}