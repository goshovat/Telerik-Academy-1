using System;

/*
    We are given a matrix of strings of size N x M. Sequences in the matrix 
    we define as sets of several neighbor elements located on the same line, 
    column or diagonal. Write a program that finds the longest sequence of 
    equal strings in the matrix.
*/

class LongestSequenceOfEqualElements
{
    public static int GetEqualElementsInLine(string[,] array, int row, int col, string str)
    {
        int numbers = 0;
        for (int j = col; j < array.GetLength(1); j++)
        {
            if (array[row, j].Equals(str))
            {
                numbers++;
            }
            else
            {
                break;
            }
        }
        return numbers;
    }

    public static int GetEqualElementsInColumn(string[,] array, int row, int col, string str)
    {
        int numbers = 0;
        for (int i = row; i < array.GetLength(0); i++)
        {
            if (array[i, col].Equals(str))
            {
                numbers++;
            }
            else
            {
                break;
            }
        }
        return numbers;
    }

    public static int GetEqualElementsInFirstDiagonal(string[,] array, int row, int col, string str)
    {
        int numbers = 0;
        for (int i = row, j = col; j < array.GetLength(1); i++, j++)
        {
            if (i == array.GetLength(0))
            {
                break;
            }
            if (array[i, j].Equals(str))
            {
                numbers++;
            }
            else
            {
                break;
            }
        }
        return numbers;
    }

    public static int GetEqualElementsInSecondDiagonal(string[,] array, int row, int col, string str)
    {
        int numbers = 0;
        for (int i = row, j = col; j >= 0; i++, j--)
        {
            if (i == array.GetLength(0))
            {
                break;
            }
            if (array[i, j].Equals(str))
            {
                numbers++;
            }
            else
            {
                break;
            }
        }
        return numbers;
    }

    public static string addSequence(string str, int duplicates)
    {
        string sequence = "";
        sequence += "{ ";
        for (int k = 0; k < duplicates; k++)
        {
            sequence += str + " ";
        }
        sequence += "} ";
        return sequence;
    }

    static void Main(string[] args)
    {
        Console.Title = "Longest sequence of equal elements in the matrix";

        Console.ForegroundColor = ConsoleColor.Green;
        int rows = 0;

        do
        {
            Console.Write("How many rows does the matrix have : ");
            rows = int.Parse(Console.ReadLine());
        } while (rows < 1); 

        int cols = 0;

        do
        {
            Console.Write("How many cols does the matrix have : ");
            cols = int.Parse(Console.ReadLine());
        } while (cols < 1); 

        string[,] rectangleMatrix = new string[rows, cols];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 25));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Element[{0},{1}] = ", row, col);
                rectangleMatrix[row, col] = Console.ReadLine();
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 25));

        int equalElementsInRow = 0;
        int equalElementsInCol = 0;
        int equalElementsInFirstDiagonal = 0;
        int equalElementsInSecondDiagonal = 0;

        int maxElements = 0;
    
        // Find the max equal elements in row, col or diagonal
        for (int i = 0; i < rectangleMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rectangleMatrix.GetLength(1); j++)
            {
                equalElementsInRow = GetEqualElementsInLine(rectangleMatrix, i, j, rectangleMatrix[i, j]);
                equalElementsInCol = GetEqualElementsInColumn(rectangleMatrix, i, j, rectangleMatrix[i, j]);
                equalElementsInFirstDiagonal = GetEqualElementsInFirstDiagonal(rectangleMatrix, i, j, rectangleMatrix[i, j]);
                equalElementsInSecondDiagonal = GetEqualElementsInSecondDiagonal(rectangleMatrix, i, j, rectangleMatrix[i, j]);

                if (equalElementsInRow > maxElements)
                {
                    maxElements = equalElementsInRow;
                }
                if (equalElementsInCol > maxElements)
                {
                    maxElements = equalElementsInCol;
                }
                if (equalElementsInFirstDiagonal > maxElements)
                {
                    maxElements = equalElementsInFirstDiagonal;
                }
                if (equalElementsInSecondDiagonal > maxElements)
                {
                    maxElements = equalElementsInSecondDiagonal;
                }
            }
        }

        // Find the sequences
        string sequences = " ";

        for (int i = 0; i < rectangleMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rectangleMatrix.GetLength(1); j++)
            {
                equalElementsInRow = GetEqualElementsInLine(rectangleMatrix, i, j, rectangleMatrix[i, j]);
                equalElementsInCol = GetEqualElementsInColumn(rectangleMatrix, i, j, rectangleMatrix[i, j]);
                equalElementsInFirstDiagonal = GetEqualElementsInFirstDiagonal(rectangleMatrix, i, j, rectangleMatrix[i, j]);
                equalElementsInSecondDiagonal = GetEqualElementsInSecondDiagonal(rectangleMatrix, i, j, rectangleMatrix[i, j]);

                if (equalElementsInRow == maxElements)
                {
                   sequences += addSequence(rectangleMatrix[i, j], maxElements);
                }
                if (equalElementsInCol == maxElements)
                {
                     sequences += addSequence(rectangleMatrix[i, j], maxElements);
                }
                if (equalElementsInFirstDiagonal == maxElements)
                {
                     sequences += addSequence(rectangleMatrix[i, j], maxElements);
                }
                if (equalElementsInSecondDiagonal == maxElements)
                {
                     sequences += addSequence(rectangleMatrix[i, j], maxElements);
                }
            }
        }

        // Print the matrix
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe matrix:");
        Console.WriteLine(new string('-', 25));
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < rectangleMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rectangleMatrix.GetLength(1); j++)
            {
                Console.Write("{0}  ", rectangleMatrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 25));

       
        if (maxElements == 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere are no equal elements in a sequence!!!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe longest sequence of equal elements has {0} elements.", maxElements);
            Console.WriteLine("The sequence(s) with max equal elements is/are :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", sequences);
        }
        Console.WriteLine();
        Console.ResetColor();
    }
}
