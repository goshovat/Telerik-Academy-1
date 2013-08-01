using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

// Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

class QuickSort
{
    static void Quicksort(int[] input, int low, int high)
    {
        int pivot = 0;

        if (low < high)
        {
            pivot = Partition(input, low, high);
            Quicksort(input, low, pivot - 1);
            Quicksort(input, pivot + 1, high);
        }
    }

    static int Partition(int[] input, int low, int high)
    {
        int pivot = input[high];
        int i = low - 1;
        int tmp = 0;

        for (int j = low; j < high; j++)
        {
            if (input[j] <= pivot)
            {
                i++;
         
                tmp = input[i];
                input[i] = input[j];
                input[j] = tmp;
            }
        }
        
        tmp = input[i + 1];
        input[i + 1] = input[high];
        input[high] = tmp;

        return i + 1;
    }

    static void Main(string[] args)
    {
        Console.Title = "Quick sort";

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
        Console.Write("\nQuick sorting by recursive method");

        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(800);
        }

        Console.WriteLine("\n\nThe sorted array is : ");
        Console.WriteLine(new string('-', 35));

        Quicksort(numbers, 0, n - 1); // You can read more about quick sorting here ---> http://en.wikipedia.org/wiki/Quicksort

        for (int i = 0; i < n; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Element [{0}] = {1}", i, numbers[i]);
            Thread.Sleep(500);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 35));

        Console.WriteLine();
        Console.ResetColor();
    }
}
