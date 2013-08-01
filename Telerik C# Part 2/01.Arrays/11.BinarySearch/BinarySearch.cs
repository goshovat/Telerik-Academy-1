using System;
using System.Linq;
using System.Threading;

/*
    Write a program that finds the index of given element in a sorted array of integers 
    by using the binary search algorithm (find it in Wikipedia).
*/

class BinarySearch
{
    static void Main(string[] args)
    {
        Console.Title = "Binary search";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("What is the number : ");
        int numberForSearch = int.Parse(Console.ReadLine());

        int size = 0;
        do
        {
            Console.Write("How many elements does the array have : ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        int[] sortedArray = new int[size];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array : ");
        Console.WriteLine(new string('-',35));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element [{0}] = ", i);
            sortedArray[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 35));

        int[] withOutDuplicates = sortedArray.Distinct().ToArray(); // Remove duplicated numbers

        bool isSorted = true;

        Console.ForegroundColor = ConsoleColor.Red;

        // Check if the array is not sorted ascending
        for (int i = 0; i < withOutDuplicates.Length - 1; i++)
        {
            if (withOutDuplicates[i] > withOutDuplicates[i + 1])
            {
                Console.WriteLine("\nThe array is not sorted!");
                isSorted = false;
                Thread.Sleep(1000);
                break;
            }
        }

        if (!isSorted)
        {
            
            Console.WriteLine("\nSorting the array...");
            Array.Sort(withOutDuplicates);
            Thread.Sleep(3000);
        }

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The sorted array : ");
        Console.WriteLine(new string('-', 35));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < withOutDuplicates.Length; i++)
        {
            Console.WriteLine("Element [{0}] = {1}", i, withOutDuplicates[i]);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 35));


        // First solution with stored method 
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nFirst solution:");
        Console.ForegroundColor = ConsoleColor.Green;
        int index = Array.BinarySearch(withOutDuplicates, numberForSearch);
        if (index < 0)
        {
            Console.WriteLine("The element {0} is not in the array!!!", numberForSearch);
        }
        else
        {
            Console.WriteLine("The element's index is {0}.", index);
        }

        // Second solution 
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nSecond solution:");

        Console.ForegroundColor = ConsoleColor.Green;
        index = BinarySearchElement(withOutDuplicates, numberForSearch);
        if (index == -1)
        {
            Console.WriteLine("The element {0} is not in the array!!!", numberForSearch);
        }
        else
        {
            Console.WriteLine("The element's index is {0}.", index);
        }

        Console.WriteLine();
        Console.ResetColor();

    }

    static int BinarySearchElement(int[] array, int value)
    {
        int low = 0, high = array.Length - 1, midpoint = 0;

        while (low <= high)
        {
            midpoint = low + (high - low) / 2;

            // Check if the element is on the current position
            if (value == array[midpoint])
            {
                return midpoint;
            }
            else if (value < array[midpoint])
                high = midpoint - 1;
            else
                low = midpoint + 1;
        }

        // Return -1 when element was not found
        return -1;
    }

}
