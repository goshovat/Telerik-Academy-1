using System;

/*
    Write a method that adds two positive integer numbers represented as 
    arrays of digits (each array element arr[i] contains a digit; the last 
    digit is kept in arr[0]). Each of the numbers that will be added could 
    have up to 10 000 digits.
*/

class PositiveIntegers
{
    public static void FillArray(int[] array, string number)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(number[number.Length - i - 1].ToString());
        }
    }

    public static int AddNumbers(int[] firstArray, int[] secondArray)
    {
        int[] result = new int[firstArray.Length > secondArray.Length ? firstArray.Length : secondArray.Length];

        if (firstArray.Length < secondArray.Length)
        {
            int[] temp = secondArray;
            secondArray = firstArray;
            firstArray = temp;
        }

        for (int i = 0; i < result.Length; i++)
        {
            if (secondArray.Length - 1 < i)
            {
                result[i] = firstArray[i];
            }
            else
            {
                result[i] = firstArray[i] + secondArray[i];
            }
        }

        string number = "";

        for (int i = 0; i < result.Length; i++)
        {
            if (i == result.Length - 1 && result[i] > 9)
            {
                number = "1";
                result[i] %= 10;
            }
            else if (result[i] > 9)
            {
                result[i] %= 10;
                result[i + 1]++;
            }
        }

        for (int i = result.Length - 1; i >= 0; i--)
        {
            number += result[i];
        }

        return int.Parse(number);
    }

    static void Main(string[] args)
    {
        Console.Title = "Adds two positive integers";

        Console.ForegroundColor = ConsoleColor.Green;

        int size = 0;
        string number = "";

        do
        {
            Console.Write("Enter the first number: ");
            number = Console.ReadLine();
            size = number.Length;
        } while (number[0].Equals('-'));

        int[] firstNumberArray = new int[size];

        FillArray(firstNumberArray, number);

        do
        {
            Console.Write("Enter the second number: ");
            number = Console.ReadLine();
            size = number.Length;
        } while (number[0].Equals('-'));

        int[] secondNumberArray = new int[size];

        FillArray(secondNumberArray, number);

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("\nThe sum of the two numbers is {0}", AddNumbers(firstNumberArray, secondNumberArray));

        Console.WriteLine();
        Console.ResetColor();
    }
}