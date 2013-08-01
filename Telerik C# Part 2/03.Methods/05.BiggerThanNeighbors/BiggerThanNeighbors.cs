using System;

/*
    Write a method that checks if the element at given position in given array
    of integers is bigger than its two neighbors (when such exist).
*/

public class BiggerThanNeighbors
{
    public static bool IsNumberBiggerThanNeighbors(int[] array, int searchNumber)
    {
        bool isBigger = false;

        if (array[searchNumber] > array[searchNumber - 1] && array[searchNumber] > array[searchNumber + 1])
        {
            isBigger = true;
        }

        return isBigger;
    }

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        int size = 0;

        do
        {
            Console.Write("How many elements does the array have: ");
            size = int.Parse(Console.ReadLine());
        } while (size < 3); // The array with 3 or more elements has at least one element with 2 neighbors

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

        int searchNumber = 0;

        Console.ForegroundColor = ConsoleColor.Green;

        do
        {
            Console.Write("\nEnter the position of the number that you want to search: ");
            searchNumber = int.Parse(Console.ReadLine());
        } while (searchNumber < 1 || searchNumber > size - 2); // Prevent from IndexOutOfException

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nDoes the number {0} at the position {1} is bigger than", array[searchNumber], searchNumber);
        Console.WriteLine("the number {0} at position {1} and ", array[searchNumber - 1], searchNumber - 1);
        Console.WriteLine("the number {0} at position {1}?", array[searchNumber + 1], searchNumber + 1);
        Console.WriteLine("Answer - {0}!", IsNumberBiggerThanNeighbors(array, searchNumber));

        Console.WriteLine();
        Console.ResetColor();
    }
}