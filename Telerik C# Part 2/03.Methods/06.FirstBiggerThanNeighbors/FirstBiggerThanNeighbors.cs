using System;

/*
    Write a method that returns the index of the first element in array that 
    is bigger than its neighbors, or -1, if there’s no such element.
    Use the method from the previous exercise.
*/

class FirstBiggerThanNeighbors
{
    public static int FirstNumberBiggerThanNeighbors(int[] array)
    {
        int index = -1;

        for (int i = 1; i < array.Length - 1; i++)
        {
            if (BiggerThanNeighbors.IsNumberBiggerThanNeighbors(array, i))
            {
                index = i;
                break;
            }
        }

        return index;
    }

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        int size = 0;

        do
        {
            Console.Write("How many elements does the array have: ");
            size = int.Parse(Console.ReadLine());
        } while (size < 3); // The array with 3 or more elements has at least one element with 2 neighbors

        int[] array = new int[size];

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nEnter the elements of the array:");
        Console.WriteLine(new string('-', 20));

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < size; i++)
        {
            Console.Write("Elements[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 20));

        int index = FirstNumberBiggerThanNeighbors(array);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nThere is an element in the array that is bigger than his neighbors - {0}",
            index == -1 ? "False" : "True");

        if (index != -1)
        {
            Console.Write("The first number is {0} at position {1}.", array[index], index);
        }

        Console.WriteLine("\n");

        Console.ResetColor();
    }
}