using System;
using System.Text;

// Write a program to convert hexadecimal numbers to their decimal representation.

class ConvertHexadecimalToDecimal
{
    private static int ToDecimal(string number)
    {
        int decimalNumber = 0;

        number = number.ToLower();

        if (number.Length == 32 && number[0].Equals('f')) // The number is negative
        {
            for (int i = number.Length - 1, power = 0; i >= 1; i--, power++)
            {
                switch (number[i])
                {
                    case 'a':
                        decimalNumber += 10 * (int)Math.Pow(16, power);
                        break;
                    case 'b':
                        decimalNumber += 11 * (int)Math.Pow(16, power);
                        break;
                    case 'c':
                        decimalNumber += 12 * (int)Math.Pow(16, power);
                        break;
                    case 'd':
                        decimalNumber += 13 * (int)Math.Pow(16, power);
                        break;
                    case 'e':
                        decimalNumber += 14 * (int)Math.Pow(16, power);
                        break;
                    case 'f':
                        decimalNumber += 15 * (int)Math.Pow(16, power);
                        break;
                    default:
                        decimalNumber += int.Parse(number[i].ToString()) * (int)Math.Pow(16, power);
                        break;
                }
            }
            decimalNumber = -(int)Math.Pow(16,8) + decimalNumber;
        }
        else // The number is positive
        {
            for (int i = number.Length - 1, power = 0; i >= 0; i--, power++)
            {
                switch (number[i])
                {
                    case 'a':
                        decimalNumber += 10 * (int)Math.Pow(16, power);
                        break;
                    case 'b':
                        decimalNumber += 11 * (int)Math.Pow(16, power);
                        break;
                    case 'c':
                        decimalNumber += 12 * (int)Math.Pow(16, power);
                        break;
                    case 'd':
                        decimalNumber += 13 * (int)Math.Pow(16, power);
                        break;
                    case 'e':
                        decimalNumber += 14 * (int)Math.Pow(16, power);
                        break;
                    case 'f':
                        decimalNumber += 15 * (int)Math.Pow(16, power);
                        break;
                    default:
                        decimalNumber += int.Parse(number[i].ToString()) * (int)Math.Pow(16, power);
                        break;
                }
            }
        }

        return decimalNumber;
    }


    public static void HexadecimalValidation(string number)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        if (number[0].Equals('-'))
        {
            Console.WriteLine("\nThe hexadecimal numbers doesn't have a sign!!!");
            Console.WriteLine();
            Environment.Exit(0);
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Convert hexadecimal number to decimal number";
        
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a hexadecimal number : ");
        string number = Console.ReadLine();

        HexadecimalValidation(number); // Check the inputed number

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe hexadecimal number is {0}", number);

        Console.WriteLine("\nThe decimal representation of the number is {0}", ToDecimal(number));
        
        // Check the result
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nThe decimal representation of the number is {0} <----- Embedded method for check ", Convert.ToInt32(number, 16));

        Console.WriteLine();
        Console.ResetColor();
    }
}