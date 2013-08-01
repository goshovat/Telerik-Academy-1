using System;
using System.Linq;

/*
    Write a program, that reads from the console an array of N integers and an integer K, 
    sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
*/

class LargestNumberInArray
{
    static void Main(string[] args)
    {
        Console.Title = "Finds the largest number in the array which is ≤ K";

        Console.ForegroundColor = ConsoleColor.Green;

        int size = 0;

        do
        {
            Console.Write("How many elements does the array have : ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[size];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 20));

        Array.Sort(array); // sort the array

        // Print the sorted array
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe sorted array:");
        Console.WriteLine(new string('-', 20));

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("Element [{0}] = {1}", i, array[i]);
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 20));

        int index = Array.BinarySearch(array, k);
        if (index > - 1) // K was found
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nK is in the array and it has index [{0}]. ", index);
            Console.WriteLine("The number is {0}.", array[index]);
        }
        else if(index == - 1) // K was not found
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAll elements are > {0} !!!", k);
        }
        else // There is a number that is < K and is bigger than the other numbers that are < K
        {
            index = ~index - 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe largest number in the array, which is < K ({0}) is with index [{1}]. ", k, index);
            Console.WriteLine("The number is {0}.", array[index]);

        }

        Console.WriteLine();
        Console.ResetColor();
    }
}
