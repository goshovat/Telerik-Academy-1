using System;
using System.Text;

// Write a program to convert decimal numbers to their binary representation.

class ConvertDecimalToBinary
{
    public static string ToBinary(int decimalNumber)
    {
        StringBuilder number = new StringBuilder();

        bool isNegativ = false;

        if (decimalNumber < 0)
        {
            decimalNumber = int.MaxValue + decimalNumber + 1;
            isNegativ = true;
        }

        do
        {
            number.Append(decimalNumber % 2);
            decimalNumber /= 2;
        } while (decimalNumber > 0);

        char[] reversDigits = number.ToString().ToCharArray();

        Array.Reverse(reversDigits);

        if (isNegativ)
        {
            StringBuilder result = new StringBuilder();
            result.Append("1" + new string(reversDigits));
            return result.ToString();
        }
        
        return new string(reversDigits);
    }

    static void Main(string[] args)
    {
        Console.Title = "Convert decimal number to binary number";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a decimal number : ");
        int number = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe decimal number is {0}", number);

        Console.WriteLine("\nThe binary representation of the number is {0}", ToBinary(number));

        // Check the result
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nThe binary representation of the number is {0} <----- Embedded method for check ", Convert.ToString(number, 2));

        Console.WriteLine();
        Console.ResetColor();
    }
}
