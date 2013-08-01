using System;

/*
    Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. 
    Print the obtained array on the console.
*/

class IntArray
{
    static void Main(string[] args)
    {
        Console.Title = "Integer array";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The following array is with 20 elements and each element \nwas initialized by its index multiplayed by 5:");
        Console.WriteLine(new string('-', 56));

        Console.ForegroundColor = ConsoleColor.Yellow;
        int[] integerArray = new int[20];

        for (int i = 0; i < integerArray.Length; i++)
        {
            integerArray[i] = i * 5;
            Console.WriteLine("{0} Array[{1}] = {2}", new string(' ', 20), i, integerArray[i]);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 56));

        Console.WriteLine();
        Console.ResetColor();
    }
}