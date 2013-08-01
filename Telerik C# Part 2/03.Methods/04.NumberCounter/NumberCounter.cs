using System;

/*
    Write a method that counts how many times given number appears in given array. 
    Write a test program to check if the method is working correctly.
*/

class NumberCounter
{
    public static int CountNumberInArray(int[] array, int number)
    {
        int counter = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                counter++;
            }
        }

        return counter;
    }

    static void Main(string[] args) 
    {
        Console.Title = "Counts how many times given number appears in given array";

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

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nEnter the number that you want to search ");
        int searchNumber = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThe number {0} appears {1} times in the array!", searchNumber, CountNumberInArray(array, searchNumber));

        Console.WriteLine();
        Console.ResetColor();
    }
}