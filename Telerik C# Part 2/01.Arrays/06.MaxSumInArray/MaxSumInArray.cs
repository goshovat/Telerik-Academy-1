using System;

/*
    Write a program that reads two integer numbers N and K and an array of N elements from the console. 
    Find in the array those K elements that have maximal sum.
*/

class MaxSumInArray
{
    static void Main(string[] args)
    {
        Console.Title = "Maximal sum in the array";

        int k = 0;

        Console.ForegroundColor = ConsoleColor.Green;
        do
        {
            Console.Write("How many elements you want to be in the sum : ");
            k = int.Parse(Console.ReadLine());
        } while (k < 1);

        int size = 0;

        do
        {
            Console.Write("What is the size of the array : ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1 || size < k);

        int[] intArray = new int[size];

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nEnter the elements of the array :");
        Console.WriteLine(new string('-', 40));
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < size; i++)
        {
            Console.Write("Element [{0}] = ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('-', 40));

        Array.Sort(intArray); // Sort the array ascending

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nThe elements with the maximal sum are: ");
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = size - 1; i >= size - k; i--)
        {
            Console.WriteLine(intArray[i]);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 40));

        Console.WriteLine();
        Console.ResetColor();
    }
}