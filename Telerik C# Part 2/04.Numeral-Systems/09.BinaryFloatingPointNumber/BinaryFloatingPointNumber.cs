using System;
using System.Text;

/*
    Write a program that shows the internal binary representation of 
    given 32-bit signed floating-point number in IEEE 754 format 
    (the C# type float). Example: -27,25 -> sign = 1, exponent = 10000011, 
    mantissa = 10110100000000000000000.
*/

class BinaryFloatingPointNumber
{
    public static int GetFirstBit(float number)
    {
        return number < 0 ? 1 : 0;
    }

    public static int GetFirstPart(int number)
    {
        return int.Parse(Convert.ToString(number, 2));
    }

    public static string GetSecondPart(float number)
    {
        int counter = 0;

        StringBuilder str = new StringBuilder();
        do
        {
            counter++;
            number = number * 2;
            str.Append((int)number);
            number = number - (int)number;
        } while (number != 0.0 && counter != 23);

        return str.ToString();
    }

    public static string GetFullMantissa(string firstPart, string secondPart)
    {
        StringBuilder mantissa = new StringBuilder();

        for (int i = 1; i < firstPart.Length; i++)
        {
            mantissa.Append(firstPart[i]);
        }

        mantissa.Append(secondPart);

        for (int i = 0; i < 23; i++)
        {
            if (i > mantissa.Length - 1)
            {
                mantissa.Append(0);
            }
        }

        return mantissa.ToString();
    }

    public static string GetExponent(int size)
    {
        return Convert.ToString(127 + size, 2);
    }

    static void Main(string[] args)
    {
        Console.Title = "Binary floating point number";

        float number = -237.63f;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("number = {0}", number);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("sign = {0}", GetFirstBit(number));

        number = Math.Abs(number);

        int firstPart = (int)number;

        int binFirst = GetFirstPart(firstPart);

        string binSecond = GetSecondPart(number - firstPart);

        int exp = binFirst.ToString().Length - 1;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("exponent = {0}", GetExponent(exp));

        string mantissa = GetFullMantissa(binFirst.ToString(), binSecond);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("mantiss = {0}", mantissa);

        Console.WriteLine();
        Console.ResetColor();
    }
}