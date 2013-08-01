using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
    Example: n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
*/

class Permutation
{
    static void Permutate(int[] array, int start, int stop)
    {
        if (start == stop)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}, ", array[i]);
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = start; i < stop; i++)
            {
                Swap(array, start, i);
                Permutate(array, start + 1, stop);
                Swap(array, start, i);
            }
        }
    }

    static void Swap(int[] array, int firstNumber, int secondNumber) // swap the number in the array
    {
        if (firstNumber == secondNumber)
        {
            return;
        }
        else
        {
            array[firstNumber] += array[secondNumber];
            array[secondNumber] = array[firstNumber] - array[secondNumber];
            array[firstNumber] -= array[secondNumber];
        }
    }


    static void Main(string[] args)
    {
        Console.Title = "Permutation of numbers [1, N]";

        Console.ForegroundColor = ConsoleColor.Green;

        int numbers = 0;

        do
        {
            Console.Write("How many numbers does the array have : ");
            numbers = int.Parse(Console.ReadLine());
        } while (numbers < 1);

        int[] array = new int[numbers];

        for (int i = 0; i < numbers; i++)
        {
            array[i] = i + 1;
        }

        Permutate(array, 0, numbers); // printing all the permutation

        Console.ResetColor();
    }
}