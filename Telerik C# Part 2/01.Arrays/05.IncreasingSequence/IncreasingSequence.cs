using System;

// Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

class IncreasingSequence
{
    static void printSequence(int[] intArray, int endPoint, int maxElements) // print the increasing sequence
    {
        Console.WriteLine("\nThe sequence looks like :");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = endPoint - maxElements; i < endPoint; i++)
        {
            Console.WriteLine("Element[{0}] = {1}", i, intArray[i]);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 20));
    }

    static void Main(string[] args)
    {
        Console.Title = "Find maximal sequence of increasing elements";

        Console.ForegroundColor = ConsoleColor.Green;

        int length = 0;
        do
        {
            Console.Write("How many elements you want to has the array : ");
            length = int.Parse(Console.ReadLine());
        } while (length < 1);
        int[] intArray = new int[length];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 20));
        Console.ForegroundColor = ConsoleColor.Yellow;

        // Initializing the array
        for (int i = 0; i < length; i++)
        {
            Console.Write("Element [{0}] = ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 20));

        int maxElements = 1;
        int currentElements = 1;
        int endPoint = 0;

        // Find the maximal sequence
        for (int j = 1; j < length; j++)
        {
            if (intArray[j - 1] == intArray[j] - 1)
            {
                currentElements++;
                if (maxElements < currentElements)
                {
                    maxElements = currentElements;
                }
            }
            else
            {
                currentElements = 1;
            }
        }

        // Check if there are no sequences with increasing elements and finish the program if it is true
        if (maxElements == 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere are no sequences with increasing elements!!!");
            Console.WriteLine();
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nThe maximal sequence is with {0} elements.", maxElements);

        currentElements = 1;

        // Check if there are more than one sequence with maximal length
        for (int j = 1; j < length; j++)
        {
            if (intArray[j - 1] == intArray[j] - 1)
            {
                currentElements++;
                if (maxElements == currentElements)
                {
                    endPoint = j + 1;
                    printSequence(intArray, endPoint, maxElements);
                }
            }
            else
            {
                currentElements = 1;
            }
        }

        if (length == 1)
        {
            printSequence(intArray, 1, 1);
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}