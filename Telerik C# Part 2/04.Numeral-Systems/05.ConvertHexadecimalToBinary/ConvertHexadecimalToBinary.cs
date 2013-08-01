using System;
using System.Text;

// Write a program to convert hexadecimal numbers to binary numbers (directly).

class ConvertHexadecimalToBinary
{
    public static string[,] hexBinNumbers = { 
                                  {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f"},
                                  {"0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"}
                                            };
    
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

    public static string ToBinary(string number)
    {
        StringBuilder binaryNumber = new StringBuilder();

        number = number.ToLower();

        for (int i = 0; i < number.Length; i++)
        {
            for (int j = 0; j < hexBinNumbers.GetLength(1); j++)
            {
                if (number[i].ToString().Equals(hexBinNumbers[0, j]))
                {
                    binaryNumber.Append(hexBinNumbers[1, j]);
                    break;
                }
            }
        }

        return binaryNumber.ToString();
    }

    static void Main(string[] args)
    {
        Console.Title = "Convert hexadecimal number to binary number";
        
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a hexadecimal number : ");
        string number = Console.ReadLine();

        HexadecimalValidation(number); // Check the inputed number

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe hexadecimal number is {0}", number);

        // Get the binary number and parse to int to remove the zeros at the beginning
        Console.WriteLine("\nThe binary representation of the number is {0}", long.Parse(ToBinary(number))); 
        
        // Check the result
        Console.ForegroundColor = ConsoleColor.Red;
        int checkResult = Convert.ToInt32(number, 16);
        Console.WriteLine("\nThe binary representation of the number is {0} <----- Embedded method for check ", Convert.ToString(checkResult, 2));

        Console.WriteLine();
        Console.ResetColor();
    }
}