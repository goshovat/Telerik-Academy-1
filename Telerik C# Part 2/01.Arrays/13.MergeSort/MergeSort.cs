using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

// Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

class MergeSort
{
    static public void DoMerge(int[] numbers, int left, int mid, int right)
    {
        int[] temp = new int[numbers.Length];
        int left_end = mid - 1;
        int num_elements = right - left + 1;
        int tmp_pos = left;
      
        while ((left <= left_end) && (mid <= right))
        {
            if (numbers[left] <= numbers[mid])
            {
                temp[tmp_pos++] = numbers[left++];
            }
            else
            {
                temp[tmp_pos++] = numbers[mid++];
            }
        }

        while (left <= left_end)
        {
            temp[tmp_pos++] = numbers[left++];
        }

        while (mid <= right)
        {
            temp[tmp_pos++] = numbers[mid++];
        }

        for (int i = 0; i < num_elements; i++)
        {
            numbers[right] = temp[right];
            right--;
        }
    }

    static public void MergeSortRecursive(int[] numbers, int left, int right)
    {
        int mid;

        if (right > left)
        {
            mid = (right + left) / 2;
            MergeSortRecursive(numbers, left, mid);
            MergeSortRecursive(numbers, (mid + 1), right);
            DoMerge(numbers, left, (mid + 1), right);
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Merge sort";

        Console.ForegroundColor = ConsoleColor.Green;

        int n = 0;
        do
        {
            Console.Write("How many elements does the array have ? - ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        int[] numbers = new int[n];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 35));

        for (int i = 0; i < n; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Element [{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 35));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nMerge sorting by recursive method");

        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(800);
        }

        Console.WriteLine("\n\nThe sorted array is : ");
        Console.WriteLine(new string('-', 35));

        MergeSortRecursive(numbers, 0, n - 1); // You can read more about merge sorting here http://en.wikipedia.org/wiki/Merge_sort

        for (int i = 0; i < n; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Element [{0}] = {1}", i, numbers[i]);
            Thread.Sleep(500);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 35));

        Console.WriteLine();
    }
}