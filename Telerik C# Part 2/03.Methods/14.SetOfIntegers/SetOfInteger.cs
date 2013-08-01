using System;
using System.Collections.Generic;

/*
    Write methods to calculate minimum, maximum, average, sum and product
    of given set of integer numbers. Use variable number of arguments.
*/

class SetOfInteger
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nMenu: ");
        Console.WriteLine(new string('-', 55));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Find the minimal element of a set");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("2. Find the maximal element of a set");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("3. Find the average of a set");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("4. Find the sum of a set");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("5. Find the product of a set");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("0. Exit");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 55));
        Console.Write("\nEnter the number of the tast that you want to solve: ");

    }

    public static void ShowSet(params int[] number)
    {
        Console.Write("\nThe set is: ");

        for (int i = 0; i < number.Length; i++)
        {
            Console.Write("{0} ", number[i]);
        }

        Console.WriteLine();
    }

    public static int GetMin(params int[] number)
    {
        int min = int.MaxValue;

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] < min)
            {
                min = number[i];
            }
        }

        return min;
    }

    public static int GetMax(params int[] number)
    {
        int max = int.MinValue;

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] > max)
            {
                max = number[i];
            }
        }

        return max;
    }

    public static double GetAverage(params int[] number)
    {
        double average = (double)GetSum(number) / number.Length;
        return average;
    }

    public static int GetSum(params int[] number)
    {
        int sum = 0;

        for (int i = 0; i < number.Length; i++)
        {
            sum += number[i];
        }

        return sum;
    }

    public static int GetProduct(params int[] number)
    {
        int product = 1;

        for (int i = 0; i < number.Length; i++)
        {
            product *= number[i];
        }

        return product;
    }

    static void Main()
    {
        Console.Title = "Set of integers";

        int choice = 0;

        do
        {
            ShowMenu();
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ShowSet(3, 5, 5, -32, -21, 2);
                    Console.WriteLine("\n---> The minimum element of the set is: {0}", GetMin(3, 5, 5, -32, -21, 2));
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    ShowSet(3, 5, 1, 2, 123, 1, 2, -213, 312, 1, 231);
                    Console.WriteLine("\n---> The maximal element of the set is: {0}", GetMax(3, 5, 1, 2, 123, 1, 2, -213, 312, 1, 231));
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    ShowSet(10, 10, 20, -10, 40, -10);
                    Console.WriteLine("\n---> The average of the set is: {0:F2}", GetAverage(10, 10, 20, -10, 40, -10));
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    ShowSet(5, 10, -20, 5, 111);
                    Console.WriteLine("\n---> The sum of the set is: {0}", GetSum(5, 10, -20, 5, 111));
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ShowSet(5, 5, 5, 10, 2);
                    Console.WriteLine("\n---> The product of the set is: {0}", GetProduct(5, 5, 5, 10, 2));
                    break;
                case 0:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n---> You have entered a wrong task!!! <---");
                    break;
            }

        } while (choice != 0);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nYou exit the menu. Goodbye!!!");
        Console.WriteLine();

        Console.ResetColor();
    }
}