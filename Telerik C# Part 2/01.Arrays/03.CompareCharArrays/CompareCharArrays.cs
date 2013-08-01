using System;

// Write a program that compares two char arrays lexicographically (letter by letter).

class CompareCharArrays
{
    static void Main(string[] args)
    {
        Console.Title = "Compare two char arrays letter by letter";
        Console.ForegroundColor = ConsoleColor.Green;

        int firstArrayLength;
        do
        {
            Console.Write("How many elements has the first char array (positive number) : ");
            firstArrayLength = int.Parse(Console.ReadLine());
        } while (firstArrayLength < 1);

        char[] firstArray = new char[firstArrayLength];

        int secondArrayLength;
        do
        {
            Console.Write("\nHow many elements has the second char array (positive number) : ");
            secondArrayLength = int.Parse(Console.ReadLine());
        } while (secondArrayLength < 1);

        char[] secondArray = new char[secondArrayLength];

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nEnter the elements for the first char array:");
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < firstArrayLength; i++)
        {
            Console.Write("Element[{0}] = ", i);
            firstArray[i] = char.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nEnter the elements for the second char array:");
        Console.WriteLine(new string('-', 40));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < secondArrayLength; i++)
        {
            Console.Write("Element[{0}] = ", i);
            secondArray[i] = char.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('-', 40));

        bool areArraysEquals = true;

        if (firstArrayLength == secondArrayLength)
        {
            for (int i = 0; i < firstArrayLength; i++)
            {
                if (!firstArray[i].Equals(secondArray[i]))
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
        Console.WriteLine("\nAre the char arrays equals? - {0}\n", areArraysEquals);
        Console.ResetColor();
    }
}
