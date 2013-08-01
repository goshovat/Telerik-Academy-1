using System;

/*
    Write a program that reads a positive integer number N (N < 20) from console 
    and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
    Example for N = 4
    
   1  2  3  4
   12 13 14 5
   11 16 15 6
   10 9  8  7
 */

class PrintSequenceInSpiral
{
    private static int[,] matrix;
    private static int n = 0;
    private static int value = 1;
    private static int row;
    private static int col;

    // Set values to the array  in a line (horizontal or vertical)
    private static void setValue(string position, int repetition)
    {
        switch (position)
        {
            case "right":
                while (true)
                {
                    matrix[row, col] = value;
                    value++;
                    repetition--;
                    if (repetition != 0)
                    {
                        col++;
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            case "down":
                while (true)
                {
                    matrix[row, col] = value;
                    value++;
                    repetition--;
                    if (repetition != 0)
                    {
                        row++;
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            case "left":
                while (repetition > 0)
                {
                    matrix[row, col] = value;
                    value++;
                    repetition--;
                    if (repetition != 0)
                    {
                        col--;
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            case "up":
                while (repetition > 0)
                {
                    matrix[row, col] = value;
                    value++;
                    repetition--;
                    if (repetition != 0)
                    {
                        row--;
                    }
                    else
                    {
                        break;
                    }
                }
                break;
        }
    }

    // print matrix to the console
    private static void printMatrix()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {


                if (matrix[i, j] < 10)
                {
                    if (matrix[i, j] == value - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("{0}", matrix[i, j]);
                        Console.ResetColor();
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0}   ", matrix[i, j]);
                    }
                }
                else if (matrix[i, j] > 9 && matrix[i, j] < 100)
                {
                    if (matrix[i, j] == value - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("{0}", matrix[i, j]);
                        Console.ResetColor();
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0}  ", matrix[i, j]);
                    }
                }
                else
                {
                    if (matrix[i, j] == value - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("{0}", matrix[i, j]);
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else
                    {

                        if (matrix[i, j] > 99 && matrix[i, j] < 200)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (matrix[i, j] > 199 && matrix[i, j] < 300)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        Console.Write("{0} ", matrix[i, j]);
                    }
                }
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.Title = "Print sequence in spiral";
        
        //
        while (n < 1 || n > 19)
        {
            Console.Write("Enter n = ");
            n = int.Parse(Console.ReadLine());
        }

        matrix = new int[n, n];

        row = 0;
        col = 0;

        int repetition = n; // how many numbers must be in a line
        string position = "right"; // how must be the line set
        setValue(position, repetition); // add the top horizontal numbers to the array

        position = "down";

        while (value < n * n) // make the spiral
        {
            repetition--;
            switch (position)
            {
                case "right":
                    col++;
                    setValue("right", repetition);
                    row++;
                    setValue("down", repetition);
                    position = "left";
                    break;
                case "down":
                    row++;
                    setValue("down", repetition);
                    col--;
                    setValue("left", repetition);
                    position = "up";
                    break;
                case "left":
                    col--;
                    setValue("left", repetition);
                    row--;
                    setValue("up", repetition);
                    position = "right";
                    break;
                case "up":
                    row--;
                    setValue("up", repetition);
                    col++;
                    setValue("right", repetition);
                    position = "down";
                    break;
            }
        }
        Console.WriteLine("\nThe spiral looks like this :");
        Console.WriteLine(new string('-', n * 4 - 1));
        printMatrix();
        Console.ResetColor();
    }
}