using System;

/*
    Write a program that reads a rectangular matrix of size N x M 
    and finds in it the square 3 x 3 that has maximal sum of its elements.
*/

class MaximalSumOfElements
{
    public static int getSum(int[,] matrix, int row, int col)
    {
        int sum = 0;
        for (int i = row; i < row + 3; i++)
        {
            for (int j = col; j < col + 3; j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
    }

    public static void printElementsWithMaxSum(int[,] matrix, int row, int col)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nThe matrix[3, 3] with maximal sum is in red color:");
        Console.WriteLine(new string('-', 25));
        for (int i = 0; i < matrix.GetLength(0) ; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == row && (j == col || j == col + 1 || j == col + 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} ", matrix[i, j]);
                }
                else if (i == row + 1 && (j == col || j == col + 1 || j == col + 2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} ", matrix[i, j]);
                }
                else if (i == row + 2 && (j == col || j == col + 1 || j == col + 2))
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
        Console.Title = "Finds the maximal sum of elements in field 3x3";
        Console.ForegroundColor = ConsoleColor.Green;
        int rows = 0;

        do
        {
            Console.Write("How many rows does the matrix have - ");
            rows = int.Parse(Console.ReadLine());
        } while (rows < 3); // because the  rectangle matrix must have at least 3 rows

        int cols = 0;

        do
        {
            Console.Write("How many cols does the matrix have - ");
            cols = int.Parse(Console.ReadLine());
        } while (cols < 3); // because the  rectangle matrix must have at least 3 cols

        int[,] rectangleMatrix = new int[rows, cols];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 25));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Element[{0},{1}] = ", row, col);
                rectangleMatrix[row, col] = int.Parse(Console.ReadLine());
            }     
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 25));

        int maxSum = int.MinValue;
        int startRow = -1;
        int startCol = -1;

        // Find the maximal sum
        for (int row = 0; row < rows - 2; row++)
        {
            int currentSum = 0;
            for (int col = 0; col < cols - 2; col++)
            {
                currentSum = getSum(rectangleMatrix, row, col);
                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        // Check if there are more matrix 3x3 with max sum and print them
        for (int row = 0; row < rows - 2; row++)
        {
            int currentSum = 0;
            for (int col = 0; col < cols - 2; col++)
            {
                currentSum = getSum(rectangleMatrix, row, col);
                if (maxSum == currentSum)
                {
                    startRow = row;
                    startCol = col;
                    printElementsWithMaxSum(rectangleMatrix, startRow, startCol);
                }
            }
        }
       
        Console.WriteLine("\nMax sum is : {0}", maxSum);

        Console.WriteLine("\n");
        Console.ResetColor();
    }
}
