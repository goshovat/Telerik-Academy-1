using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Write a program that finds in given array of integers a sequence of given sum S (if present). 
    Example: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}	
*/

class SequenceOfGivenSum
{
    static void Main(string[] args)
    {
        Console.Title = "Sequence of given sum";

        int length = 0;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter sum : ");
        int sum = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("Enter the length of the array (positive number) : ");
            length = int.Parse(Console.ReadLine());
        } while (length < 1);

        int[] array = new int[length];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array : ");
        Console.WriteLine(new string('-', 35));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < length; i++)
        {
            Console.Write("Elemetn [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 35));

        StringBuilder elements = new StringBuilder();
        int tempSum = 0;
        bool hasSum = false;

        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < length; i++)
        {
            for (int j = i; j < length; j++)
            {
                tempSum += array[j];
                elements.Append(array[j]);
                elements.Append(", ");

                if (tempSum == sum)
                {
                    Console.Write("\nThe following sequences has sum = {0} :  {1}", sum, elements);
                    hasSum = true;
                }
            }
            tempSum = 0;
            elements = new StringBuilder();
        }

        if (!hasSum)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere are no sequences with sum = {0}!!!", sum);
        }

        Console.WriteLine("\n");
        Console.ResetColor();
    }
}

