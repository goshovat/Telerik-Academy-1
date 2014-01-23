using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SpecialValue
{
    class SpecialValue
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            char[] separators = { ',', ' ' };

            int[][] indexes = new int [lines][];

            for (int i = 0; i < lines; i++)
			{
                string[] columns = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                indexes[i] = new int[columns.Length];

                for (int j = 0; j < columns.Length; j++)
                {
                    indexes[i][j] = int.Parse(columns[j]);
                }
			}

            long maxSpecialValue = long.MinValue;
            long currentSpecialValue = 0;

            for (int i = 0; i < indexes[0].Length; i++)
            {
                currentSpecialValue = GetSpecialValue(indexes, i);
                if (currentSpecialValue > maxSpecialValue)
                {
                    maxSpecialValue = currentSpecialValue;
                }
            }

            Console.WriteLine(maxSpecialValue);
        }


        private static long GetSpecialValue(int[][] indexes, int startPoint)
        {
            long specialValue = 1;

            bool[][] isVisited = new bool[indexes.Length][];

            int row = 0;
            int col = startPoint;

            for (int i = 0; i < indexes.Length; i++)
            {
                isVisited[i] = new bool[indexes[i].Length];
            }

            while (true)
            {
                if (isVisited[row][col])
                {
                    specialValue = int.MinValue;
                    break;
                }

                if (indexes[row][col] < 0)
                {
                    specialValue += Math.Abs(indexes[row][col]);
                    break;
                }

                isVisited[row][col] = true;

                col = indexes[row][col];

                specialValue++;

                row++;

                if (row == isVisited.Length)
                {
                    row = 0;
                }
            }

            return specialValue;
        }
    }
}
