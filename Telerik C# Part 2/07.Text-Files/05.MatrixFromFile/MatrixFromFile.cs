using System;
using System.IO;

/*
    Write a program that reads a text file containing a square matrix of numbers and finds in the matrix 
    an area of size 2 x 2 with a maximal sum of its elements. The first line in the input file contains 
    the size of matrix N. Each of the next N lines contain N numbers separated by space. The output should 
    be a single number in a separate text file. Example:
    
    4
    2 3 3 4
    0 2 3 4	 -----> 17
    3 7 1 2
    4 3 3 2
*/

class MatrixFromFile
{
    public static int getSum(int[,] matrix, int row, int col)
    {
        return matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];       
    }

    public static void printElementsWithMaxSum(int[,] matrix, int row, int col)
    {
        System.Threading.Thread.Sleep(1500); // Delay the program with 1.5 sec
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nThe area[2, 2] with maximal sum is in red color:");
        Console.WriteLine(new string('-', 25));
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == row && (j == col || j == col + 1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} ", matrix[i, j]);
                }
                else if (i == row + 1 && (j == col || j == col + 1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} ", matrix[i, j]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0} ", matrix[i, j]);
                }
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 25));
    }


    static void Main(string[] args)
    {
        Console.Title = "Matrix that was read from file";

        Console.ForegroundColor = ConsoleColor.Green;

        StreamReader input = new StreamReader("Matrix.txt");

        using (input)
        {
            int size = int.Parse(input.ReadLine());

            int[,] matrix = new int[size, size];

            // Get the elements of the matrix from the file and print them to the console
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThe elements of the array:");
            Console.WriteLine(new string('-', 25));

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int row = 0; row < size; row++)
            {
                string[] line = input.ReadLine().Split(' ');

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 25));

            int maxSum = int.MinValue;
            int startRow = -1;
            int startCol = -1;

            // Find the maximal sum
            for (int row = 0; row < size - 1; row++)
            {
                int currentSum = 0;
                for (int col = 0; col < size - 1; col++)
                {
                    currentSum = getSum(matrix, row, col);
                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }

            // Check if there are more matrix 2x2 with max sum and print them
            for (int row = 0; row < size - 1; row++)
            {
                int currentSum = 0;
                for (int col = 0; col < size - 1; col++)
                {
                    currentSum = getSum(matrix, row, col);
                    if (maxSum == currentSum)
                    {
                        startRow = row;
                        startCol = col;
                        printElementsWithMaxSum(matrix, startRow, startCol);
                    }
                }
            }

            Console.WriteLine("\nMax sum is : {0}", maxSum);
        }

        Console.WriteLine("\n");
        Console.ResetColor();
    }
}
