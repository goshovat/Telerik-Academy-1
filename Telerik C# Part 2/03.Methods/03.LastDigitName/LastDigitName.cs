using System;

/*
    Write a method that returns the last digit of given integer as an English word. 
    Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".
*/

class LastDigitName
{
    public static string GetLastDigitName(int number)
    {
        int lastDigit = number % 10;
        string digitName = "";

        switch (lastDigit)
        {
            case 0:
                digitName = "zero";
                break;
            case 1:
                digitName = "one";
                break;
            case 2:
                digitName = "two";
                break;
            case 3:
                digitName = "three";
                break;
            case 4:
                digitName = "four";
                break;
            case 5:
                digitName = "five";
                break;
            case 6:
                digitName = "six";
                break;
            case 7:
                digitName = "seven";
                break;
            case 8:
                digitName = "eight";
                break;
            case 9:
                digitName = "nine";
                break;
        }

        return digitName;
    }

    static void Main(string[] args)
    {
        Console.Title = "Print the last digit's name of a given integer";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter the number: ");
        int number = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe last digit's name of the number {0} is {1}!\n", number, GetLastDigitName(number));

        Console.ResetColor();
    }
}
