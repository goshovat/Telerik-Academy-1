using System;

// Write a program that reads two arrays from the console and compares them element by element.

class CompareArrays
{
    static void Main(string[] args)
    {
        Console.Title = "Compare two arrays element by element";
        Console.ForegroundColor = ConsoleColor.Green;

        int firstArrayLength;

        do
        {
            Console.Write("How many elements has the first array (positive number) : ");
            firstArrayLength = int.Parse(Console.ReadLine());
        } while (firstArrayLength < 1);

        string[] firstArray = new string[firstArrayLength];
        // The type of the array is string because in the task there is no information about the type.
        // I choosed string because it can be used for comparing of all numeric types and text types 

        int secondArrayLength;

        do
        {
            Console.Write("\nHow many elements has the second array (positive number) : ");
            secondArrayLength = int.Parse(Console.ReadLine());
        } while (secondArrayLength < 1);

        string[] secondArray = new string[secondArrayLength];

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nEnter the elements for the first array:");
        Console.WriteLine(new string('-', 40));
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < firstArrayLength; i++)
        {
            Console.Write("Element[{0}] = ", i);
            firstArray[i] = Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nEnter the elements for the second array:");
        Console.WriteLine(new string('-', 40));
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < secondArrayLength; i++)
        {
            Console.Write("Element[{0}] = ", i);
            secondArray[i] = Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('-', 40));

        bool areArraysEquals = true;

        if (firstArrayLength == secondArrayLength)
        {
            for (int i = 0; i < firstArrayLength; i++)
            {
                if (!firstArray[i].Equals(secondArray[i])) // if the arrays' type is numeric type, the operator will be == insted of the mothod Equals()
                {
                    areArraysEquals = false;
                    break;
                }
            }
        }
        else
        {
            areArraysEquals = false;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nAre the arrays equals? - {0}", areArraysEquals);

        Console.WriteLine();
        Console.ResetColor();
    }
}