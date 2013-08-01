using System;
using System.Text;

/*
    Write a program that can solve these tasks:
        - Reverses the digits of a number
        - Calculates the average of a sequence of integers
        - Solves a linear equation a * x + b = 0
	Create appropriate methods.
    Provide a simple text-based menu for the user to choose which task to solve.
    Validate the input data:
        - The decimal number should be non-negative
        - The sequence should not be empty
        - a should not be equal to 0
*/


class Menu
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nMenu: ");
        Console.WriteLine(new string('-',55));

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Reverses the digits of a number");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("2. Calculates the average of a sequence of integers");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("3. Solves a linear equation a * x + b = 0");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("0. Exit");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 55));
        Console.Write("\nEnter the number of the tast that you want to solve: ");
    }

    public static void EnterNumber()
    {
        Console.ForegroundColor = ConsoleColor.White;

        decimal number = -1;

        do
        {
            Console.Write("\nEnter a positive number: ");
            number = decimal.Parse(Console.ReadLine());
        } while (number < 1);

        ReverseDigits(number);
    }

    public static void ReverseDigits(decimal number)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        StringBuilder reversedNumber = new StringBuilder();

        do
        {
            reversedNumber.Append(Math.Truncate(number % 10));
            number = Math.Truncate(number / 10);
        } while (number > 0);

        Console.WriteLine("The reversed number is {0}", reversedNumber);
    }

    public static void EnterSequence()
    {
        Console.ForegroundColor = ConsoleColor.White;

        int size = 0;
        do
        {
            Console.Write("\nHow many elements does the sequence have: ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        Console.WriteLine("\nEnter the elements of the sequence:");
        Console.WriteLine(new string('-', 35));

        int[] array = new int[size];

        Console.ForegroundColor = ConsoleColor.Cyan;

        for (int i = 0; i < size; i++)
        {
            Console.Write("Element [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('-', 35));

        GetAverage(array);
    }

    public static void GetAverage(int[] numbers)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        int sum = 0;
        decimal average = 0;

        foreach (int item in numbers)
        {
            sum += item;
        }

        average = (decimal)sum / numbers.Length;

        Console.WriteLine("\nThe average of the sequence is {0:F2}", average);
    }

    public static void EnterCoefficients()
    {
        Console.ForegroundColor = ConsoleColor.White;

        int a = 0;

        do
        {
            Console.Write("\nEnter coefficient \"a\" = ");
            a = int.Parse(Console.ReadLine());
        } while (a == 0);

        Console.Write("Enter coefficient \"b\" = ");
        int b = int.Parse(Console.ReadLine());

        if (b > 0)
        {
            Console.WriteLine("\nThe equation is {0}*x + {1} = 0", a, b);
        }
        else if (b < 0)
        {
            Console.WriteLine("\nThe equation is {0}*x {1} = 0", a, b);
        }
        else
        {
            Console.WriteLine("\nThe equation is {0}*x = 0", a);
        }
   
        ShowRoot(a, b);
    }

    public static void ShowRoot(int a, int b)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        decimal root = -(decimal)b / a;
        Console.WriteLine("x = {0:F4}", root);
    }

    static void Main(string[] args)
    {
        Console.Title = "Menu";
        
        int choice = 0;

        do
        {
            ShowMenu();
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    EnterNumber();
                    System.Threading.Thread.Sleep(4000);
                    break;
                case 2:
                    EnterSequence();
                    System.Threading.Thread.Sleep(6000);
                    break;
                case 3:
                    EnterCoefficients();
                    System.Threading.Thread.Sleep(6000);
                    break;
                case 0:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n--->You have entered a wrong task!!!<---");
                    System.Threading.Thread.Sleep(4000);
                    break;
            }

            Console.Clear();
        } while(choice != 0);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nYou exit the menu. Goodbye!!!");
        Console.WriteLine();

        Console.ResetColor();
    }
}