using System;
using System.Text;

// Write a program to convert binary numbers to hexadecimal numbers (directly).

class ConvertBinaryToHexadecimal
{
    public static string[,] hexBinNumbers = { 
                                  {"0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"},
                                  {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f"}
                                            };

    private static string ToHexadecimal(string number)
    {
        int index = number.Length % 4;
        
        if (index != 0)
        {
            for (int i = 0; i < 4 - index; i++)
            {
                number = "0" + number;
            }    
        }

        StringBuilder hexadecimalNumber = new StringBuilder();

        for (int i = 0; i < number.Length; i = i + 4)
        {
            for (int j = 0; j < hexBinNumbers.GetLength(1); j++)
            {
                if (number.Substring(i, 4).Equals(hexBinNumbers[0, j]))
                {
                    hexadecimalNumber.Append(hexBinNumbers[1, j]);
                    break;
                }
            }
        }

        return hexadecimalNumber.ToString();
    }


    public static void BinaryValidation(string number)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        bool isCorrect = true;

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i].Equals('2') ||
                number[i].Equals('3') ||
                number[i].Equals('4') ||
                number[i].Equals('5') ||
                number[i].Equals('6') ||
                number[i].Equals('7') ||
                number[i].Equals('8') ||
                number[i].Equals('9'))
            {
                isCorrect = false;
                break;
            }
        }

        if (number[0].Equals('-'))
        {
            Console.WriteLine("\nThe binary numbers doesn't have a sign!!!");
            Console.WriteLine();
            Environment.Exit(0);
        }
        else if (!isCorrect)
        {
            Console.WriteLine("\nThe binary numbers contain only \"0\" and \"1\"!!!");
            Console.WriteLine();
            Environment.Exit(0);
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Convert binary number to hexadecimal number";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a binary number : ");
        string number = Console.ReadLine();

        BinaryValidation(number); // Check the inputed number

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe binary number is {0}", number);

        Console.WriteLine("\nThe hexadecimal representation of the number is {0}", ToHexadecimal(number));

        // Check the result
        Console.ForegroundColor = ConsoleColor.Red;
        int checkResult = Convert.ToInt32(number, 2);
        Console.WriteLine("\nThe hexadecimal representation of the number is {0} <----- Embedded method for check ", Convert.ToString(checkResult, 16));

        Console.WriteLine();
        Console.ResetColor();

    }
}