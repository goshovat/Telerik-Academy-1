using System;

class Variation
{
    static void PrintVariation(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(" {0}", array[i]);
        }
        Console.WriteLine();
    }

    static void Variate(int[] array, int numbers, int position)
    {
        if (position == array.Length)
        {
            PrintVariation(array);
            return;
        }
        else
        {
            for (int element = 0; element < numbers; element++)
            {
                array[position] = element + 1;
                Variate(array, numbers, position + 1);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Variation of numbers [1, N]";

        Console.ForegroundColor = ConsoleColor.Green;

        int numbers = 0;
        int variationNumber = 0;

        do
        {
            Console.Write("How many numbers does the array have : ");
            numbers = int.Parse(Console.ReadLine());
        } while (numbers < 1);

        do
        {
            Console.Write("How many numbers does the variation have : ");
            variationNumber = int.Parse(Console.ReadLine());
        } while (numbers < 1);

        int[] array = new int[variationNumber];

        Variate(array, numbers, 0);

        Console.ResetColor();
    }
}
