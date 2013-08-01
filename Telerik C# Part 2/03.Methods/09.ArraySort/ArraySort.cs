using System;

/*
    Write a method that return the maximal element in a portion of array 
    of integers starting at given index. Using it write another method that 
    sorts an array in ascending / descending order.
*/

class ArraySort
{
    public static int GetMax(int[] array, int position, int stopPoint)
    {
        int max = array[position];
        int index = position;

        for (int i = position; i < stopPoint; i++)
        {
            if (max < array[i])
            {
                max = array[i];
                index = i;
            }
        }

        return index;
    }

    public static void SortDescending(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int index = GetMax(array, i + 1, array.Length);

            if (array[i] < array[index])
            {
                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }
        }
        Console.WriteLine();
        PrintArray(array);
    }

    public static void SortAscending(int[] array)
    {
        for (int i = array.Length - 1; i >= 1; i--)
        {
            int index = GetMax(array, 0, i - 1);

            if (array[i] < array[index])
            {
                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }
        }
        Console.WriteLine();
        PrintArray(array);
    }

    public static void PrintArray(int[] array)
    {
        Console.Write("The sorted array: ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Sorting an array";

        Console.ForegroundColor = ConsoleColor.Green;

        int size = 0;

        do
        {
            Console.Write("How many elements does the array have: ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        int[] array = new int[size];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < size; i++)
        {
            Console.Write("Elements[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 20));

        // Sort descending
        Console.ForegroundColor = ConsoleColor.Magenta;
        SortDescending(array);

        // Sort ascending
        Console.ForegroundColor = ConsoleColor.Magenta;
        SortAscending(array);

        Console.WriteLine("\n");
        Console.ResetColor();
    }
}