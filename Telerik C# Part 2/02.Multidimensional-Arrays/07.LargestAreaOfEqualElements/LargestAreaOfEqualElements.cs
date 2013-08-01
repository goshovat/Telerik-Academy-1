using System;
using System.Collections.Generic;

// Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.

class LargestAreaOfEqualElements
{
    static int[,] matrix;
    static List<bool[,]> maxArea;
    static bool[,] currentArea;
    static int maxNeighbors = int.MinValue;
    static int currentNeighbors = 0;

    static void FindPath(int row, int col, int value)
    {
        if ((col < 0) || (row < 0) || (col >= matrix.GetLength(1)) || (row >= matrix.GetLength(0)))
        {
            // We are out of the matrix
            return;
        }

        if (currentArea[row, col] == true)
        {
            // The current area was checked
            return;
        }

        if (matrix[row, col] == value)
        {
            currentNeighbors++;
            currentArea[row, col] = true;
            CheckNeightbors(currentNeighbors);

            FindPath(row, col - 1, matrix[row, col]); // going left
            FindPath(row - 1, col, matrix[row, col]); // going up
            FindPath(row, col + 1, matrix[row, col]); // going right
            FindPath(row + 1, col, matrix[row, col]); // going down

            currentNeighbors--;
        }
    }

    static void CheckNeightbors(int neighbors)
    {
        if (neighbors > maxNeighbors)
        {
            maxArea = new List<bool[,]>();
            maxNeighbors = neighbors;
            maxArea.Add(currentArea);
        }
        else if (neighbors == maxNeighbors)
        {
            maxArea.Add(currentArea);
        }
    }

    static void PrintArea(int[,] area)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The matrix:");
        Console.WriteLine(new string('-', area.GetLength(1) * 3));

        for (int i = 0; i < area.GetLength(0); i++)
        {
            for (int j = 0; j < area.GetLength(1); j++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0, 2} ", matrix[i, j]);
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', area.GetLength(1) * 3));
    }

    static void PrintMaxArea(bool[,] area)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The max arae with equal neighbors is with {0} elements:", maxNeighbors);
        Console.WriteLine(new string('-', area.GetLength(1) * 3));

        for (int i = 0; i < area.GetLength(0); i++)
        {
            for (int j = 0; j < area.GetLength(1); j++)
            {
                if (area[i, j] == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("{0, 2} ", matrix[i, j]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0, 2} ", matrix[i, j]);
                }
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', area.GetLength(1) * 3));

    }

    public static void EqualElements(List<bool[,]> elements, bool[,] check, int starPoint)
    {
        bool toDelete = true;

        for (int i = starPoint; i < elements.Count; i++)
        {
            for (int j = 0; j < elements[i].GetLength(0); j++)
            {
                for (int k = 0; k < elements[i].GetLength(1); k++)
                {
                    if (elements[i][j, k] != check[j, k])
                    {
                        toDelete = false;
                    }
                }
            }

            if (toDelete)
            {
                elements.Remove(elements[i]);
                i = starPoint - 1;
            }
            else
            {
                toDelete = true;
            }
        }
    }

    public static void Correct(List<bool[,]> elements)
    {
        int max = 0;

        // Find max neighbours
        for (int i = 0; i < elements.Count; i++)
        {
            for (int j = 0; j < elements[i].GetLength(0); j++)
            {
                for (int k = 0; k < elements[i].GetLength(1); k++)
                {
                    if (elements[i][j, k])
                    {
                        max++;
                    }
                }
            }

            if (maxNeighbors < max)
            {
                maxNeighbors = max;
            }
            max = 0;
        }


        // Remove useless elements
        for (int i = 0; i < elements.Count; i++)
        {
            for (int j = 0; j < elements[i].GetLength(0); j++)
            {
                for (int k = 0; k < elements[i].GetLength(1); k++)
                {
                    if (elements[i][j, k])
                    {
                        max++;
                    }
                }
            }
            if (maxNeighbors > max)
            {
                elements.Remove(elements[i]);
                i--;
            }
            max = 0;
        }
    }

    static void Main()
    {
        Console.Title = "Find largest area of equal elements";

        Random randomNumber = new Random();

        int rows;
        int cols;

        do
        {
            rows = randomNumber.Next(10);
            cols = randomNumber.Next(10);
        } while (rows < 1 || cols < 1);


        matrix = new int[rows, cols];
        currentArea = new bool[rows, cols];
        maxArea = new List<bool[,]>();

        // Enter random numbers to the matrix
        for (int i = 0; i < matrix.GetLongLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLongLength(1); j++)
            {
                matrix[i, j] = randomNumber.Next(5);
            }
        }

        // Print the matrix
        PrintArea(matrix);
        Console.WriteLine();

        // Find max area with equal elements
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                currentArea = new bool[rows, cols];
                FindPath(i, j, matrix[i, j]);
            }
        }

        // Correct the matrix if there are some mistakes
        Correct(maxArea);

        // Check for equal elements and remove duplicates
        for (int i = 0; i < maxArea.Count - 1; i++)
        {
            EqualElements(maxArea, maxArea[i], i + 1);
        }

        // Print the area(s)
        for (int i = 0; i < maxArea.Count; i++)
        {
            PrintMaxArea(maxArea[i]);
            Console.WriteLine();
        }

        Console.ResetColor();

    }
}