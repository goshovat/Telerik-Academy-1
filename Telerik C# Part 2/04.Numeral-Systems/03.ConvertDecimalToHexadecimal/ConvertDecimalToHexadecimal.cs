using System;
using System.Text;

// Write a program to convert decimal numbers to their hexadecimal representation.

class ConvertDecimalToHexadecimal
{
    public static String GetHexadecimalRepresentation(dynamic decNumber)
    {
        StringBuilder number = new StringBuilder();

        do
        {
            int temp = (int)(decNumber % 16);
            switch (temp)
            {
                case 10:
                    number.Append("a");
                    break;
                case 11:
                    number.Append("b");
                    break;
                case 12:
                    number.Append("c");
                    break;
                case 13:
                    number.Append("d");
                    break;
                case 14:
                    number.Append("e");
                    break;
                case 15:
                    number.Append("f");
                    break;
                default:
                    number.Append(temp);
                    break;
            }
            decNumber /= 16;
        } while (decNumber > 0);

        return number.ToString();
    }

    public static string ToHexadecimal(int decimalNumber)
    {
        long negativeNumber = 0;
        char[] reversDigits;

        if (decimalNumber < 0)
        {
            negativeNumber = decimalNumber + (long)Math.Pow(16, 8);
            reversDigits = GetHexadecimalRepresentation(negativeNumber).ToCharArray();
        }
        else
        {
            reversDigits = GetHexadecimalRepresentation(decimalNumber).ToCharArray();
        }

        Array.Reverse(reversDigits);

        return new string(reversDigits);
    }

    static void Main(string[] args)
    {
        Console.Title = "Convert decimal number to hexadecimal number";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a decimal number : ");
        int number = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe decimal number is {0}", number);

        Console.WriteLine("\nThe hexadecimal representation of the number is {0}", ToHexadecimal(number));

        // Check the result
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nThe hexadecimal representation of the number is {0} <----- Embedded method for check ", Convert.ToString(number, 16));

        Console.WriteLine();
        Console.ResetColor();
    }
}
