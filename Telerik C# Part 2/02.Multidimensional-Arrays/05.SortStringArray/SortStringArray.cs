using System;
using System.Threading;

/*
    You are given an array of strings. Write a method that sorts the array 
     by the length of its elements (the number of characters composing them).
*/

class SortStringArray
{

    static void printArray(string[] array, int i, int j)
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
        Console.Title = "Sorting string array";

        Console.ForegroundColor = ConsoleColor.Green;

        int size = 0;

        do
        {
            Console.Write("What is the size of the array : ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        string[] array = new string[size];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < size; i++)
        {
            Console.Write("String [{0}] = ", i);
            array[i] = Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 20));

        // Merge sorting
        int min = int.MaxValue;
        int index = 0;
        string tempString = "";

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\nSorting...");
        Console.WriteLine(new string('-', 40));
        for (int i = 0; i < size - 1; i++)
        {
            min = int.MaxValue;
            index = 0;
            for (int j = i + 1; j < size; j++)
            {
                if (min > array[j].Length)
                {
                    min = array[j].Length; // Get minimal length from the remaining elements
                    index = j; // save the index of minimal length
                }
                else if (min == array[j].Length)
                {
                    if (array[j].CompareTo(array[index]) < 0) // Check the lexicographical ordinance
                    {
                        index = j; // save the index of minimal length from remaining elements
                    }
                }
            }

            printArray(array, i, index); // Show the array and the elements that are going to be checked

            if (min < array[i].Length) // Check if the two elements are not sorted  and swap them
            {
                tempString = array[index];
                array[index] = array[i];
                array[i] = tempString;

            }
            else if (min == array[i].Length)
            {
                if (array[i].CompareTo(array[index]) > 0 ) // Check the lexicographical ordinance
                {
                    tempString = array[index];
                    array[index] = array[i];
                    array[i] = tempString;
                }
            }

            Thread.Sleep(2000); // The console application stop working (sleep) for 2 sec to see the changes that are made
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nThe sorted array is : ");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < size; i++) // Printing the sorted array
        {
            Console.WriteLine("String [{0}] = {1} ", i, array[i]);
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(new string('-', 20));

        Console.WriteLine("\n");
        Console.ResetColor();
    }
}