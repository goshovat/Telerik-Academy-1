using System;
using System.Linq;
using System.Collections.Generic;

/*
    Write a program that finds the most frequent number in an array. Example:
	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
*/

class MostFrequentNumberInArray
{
    static void Main(string[] args)
    {
        Console.Title = "Most frequent number in an array";

        Console.ForegroundColor = ConsoleColor.Green;
        int length = 0;
        do
        {
            Console.Write("Enter the length of the array : ");
            length = int.Parse(Console.ReadLine());
        } while (length < 1);

        int[] array = new int[length];

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 40));


        // First solution
        Array.Sort(array);

        int countNumbers = 1;
        int max = 1;

        List<int> frequentNumbers = new List<int>();
        frequentNumbers.Add(array[0]);

        for (int i = 1; i < length; i++)
        {
            if (array[i] == array[i - 1])
            {
                countNumbers++;

                if (countNumbers > max)
                {
                    max = countNumbers;
                    frequentNumbers.Clear();
                    frequentNumbers.Add(array[i]);
                }
                else if (countNumbers == max)
                {
                    frequentNumbers.Add(array[i]);
                }
            }
            else
            {
                countNumbers = 1;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nSecond solution.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("The most frequent number in the array is : ");
        if (max == 1)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ({1} times), ", array[i], max);
            }
        }
        else
        {
            for (int i = 0; i < frequentNumbers.Count; i++)
            {
                Console.Write("{0} ({1} times), ", frequentNumbers[i], max);
            }
        }

        Console.WriteLine();

        // Second solution - It is not working for large integers and negative numbers
        int maxNumber = array.Max();

        int[] tempArray = new int[maxNumber + 1];

        for (int i = 0; i < length; i++)
        {
            tempArray[array[i]]++;
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nSecond solution.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("The most frequent number in the array is : ");
        for (int i = 1; i < maxNumber + 1; i++)
        {
            if (tempArray[i] == tempArray.Max())
            {
                Console.Write("{0} ({1} times), ", i, tempArray.Max());
            }
        }

        Console.ResetColor();
        Console.WriteLine("\n");
    }
}