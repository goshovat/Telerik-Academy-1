namespace Generator
{
    using System;

    public class ArrayGenerator
    {
        private readonly Random generator = new Random();

        public int[] GenerateArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = generator.Next();
            }

            return array;
        }

        public int[,] GenerateTwoDimensionalArray(int rows, int cols)
        {
            int[,] twoDimensionalArray = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    twoDimensionalArray[i, j] = generator.Next();

                }
            }

            return twoDimensionalArray;
        }
    }
}
