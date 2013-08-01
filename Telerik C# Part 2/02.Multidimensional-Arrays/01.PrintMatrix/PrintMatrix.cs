using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
    A)           B)
    1 8 9  16    1 5 9  13    
    2 7 10 15    2 6 10 14    
    3 6 11 14    3 7 11 15    
    4 5 12 13    4 8 12 16    
 
    C)           D)
    7 11 14 16   1  12 11 10
    4 8  12 15   2  13 16 9
    2 5  9  13   3  14 15 8
    1 3  6  10   4  5  6  7
*/

class PrintMatrix
{
    private static int[,] matrix;
    private static int value = 1;
    private static int row;
    private static int col;

    // print matrix to the console
    private static void PrintFullMatrix(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
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
    }

    // ------------> Task D <------------
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

    static void Main(string[] args)
    {
        Console.Title = "Print different matrixs";

        Console.ForegroundColor = ConsoleColor.Green;

        int counter = 1;

        int size = 0;

        do
        {
            Console.Write("Enter the size of the array : ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        matrix = new int[size, size];

        Console.WriteLine();

        // ------------> Task A <------------
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[j, i] = counter;
                counter++;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("------------> Task A <------------");
        Console.WriteLine(new string('-', size * 4 - 1));
        PrintFullMatrix(size);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', size * 4 - 1));
        counter = 1;

        Console.WriteLine();

        // ------------> Task B <------------
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i % 2 == 0)
                {
                    matrix[j, i] = counter;
                    counter++;
                }
                else
                {
                    matrix[size - j - 1, i] = counter;
                    counter++;
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("------------> Task B <------------");
        Console.WriteLine(new string('-', size * 4 - 1));
        PrintFullMatrix(size);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', size * 4 - 1));
        counter = 0;

        Console.WriteLine();

        // ------------> Task C <------------        
        for (int i = size - 1; i >= 0; i--)
        {
            for (int j = 0, k = i; j < size; j++, k++)
            {
                if (k == size)
                {
                    break;
                }
                counter++;
                matrix[k, j] = counter;
            }
        }

        for (int j = 1; j < size; j++)
        {
            for (int i = 0, k = j; i < size - 1; i++, k++)
            {
                if (k == size)
                {
                    break;
                }
                counter++;
                matrix[i, k] = counter;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("------------> Task C <------------");
        Console.WriteLine(new string('-', size * 4 - 1));
        PrintFullMatrix(size);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', size * 4 - 1));
        counter = 0;

        Console.WriteLine();

        // ------------> Task D <------------
        row = 0;
        col = 0;

        int repetition = size; // how many numbers must be in a line
        string position = "down"; // how must be the line set
        setValue(position, repetition); // add the top horizontal numbers to the array

        position = "right";

        while (value < size * size) // make the spiral
        {
            repetition--;
            switch (position)
            {
                case "right":
                    col++;
                    setValue("right", repetition);
                    row--;
                    setValue("up", repetition);
                    position = "left";
                    break;
                case "down":
                    row++;
                    setValue("down", repetition);
                    col++;
                    setValue("right", repetition);
                    position = "up";
                    break;
                case "left":
                    col--;
                    setValue("left", repetition);
                    row++;
                    setValue("down", repetition);
                    position = "right";
                    break;
                case "up":
                    row--;
                    setValue("up", repetition);
                    col--;
                    setValue("left", repetition);
                    position = "down";
                    break;
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("------------> Task D <------------");
        Console.WriteLine(new string('-', size * 4 - 1));
        PrintFullMatrix(size);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', size * 4 - 1));
        Console.ResetColor();

        Console.WriteLine("\n");
    }
}