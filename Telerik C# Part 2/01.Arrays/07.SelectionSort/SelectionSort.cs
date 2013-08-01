using System;
using System.Threading;

/*
    Sorting an array means to arrange its elements in increasing order. 
    Write a program to sort an array. Use the "selection sort" algorithm: 
    Find the smallest element, move it at the first position, find the smallest from the rest,
    move it at the second position, etc.
*/

class SelectionSort
{

    static void printArray(int[] array, int i, int j)
    {
        for (int k = 0; k < array.Length; k++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (k == j || k == i)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Element [{0}] = {1} <-------", k, array[k]);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.WriteLine("Element [{0}] = {1} ", k, array[k]);
            }
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(new string('-', 40));
    }

    static void Main(string[] args)
    {
        Console.Title = "Selection sort";

        Console.ForegroundColor = ConsoleColor.Green;

        int n = 0;
        do
        {
            Console.Write("How many elements does the array have : ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        int[] arrayToSort = new int[n];

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Element [{0}] = ", i);
            arrayToSort[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 40));

        int min = int.MaxValue;
        int index = 0;

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\nSorting...");
        Console.WriteLine(new string('-', 40));
        for (int i = 0; i < n - 1; i++)
        {
            min = int.MaxValue;
            index = 0;
            for (int j = i + 1; j < n; j++)
            {
                if (min > arrayToSort[j])
                {
                    min = arrayToSort[j]; // Get minimal value from the remaining elements
                    index = j;
                }
            }

            printArray(arrayToSort, i, index); // Show the array and the elements that are going to be swap

            if (min < arrayToSort[i]) // Check if the two elements are not sorted  and swap them
            {
                arrayToSort[index] = arrayToSort[i];
                arrayToSort[i] = min;
            }

            Thread.Sleep(2000); // The console application stop working (sleep) for 2 sec to see the changes that are made
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nThe sorted array is : ");
        for (int i = 0; i < n; i++) // Printing the sorted array
        {
            Console.Write("{0}, ", arrayToSort[i]);
        }
        Console.WriteLine("\n");
        Console.ResetColor();
    }
}