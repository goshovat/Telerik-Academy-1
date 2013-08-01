using System;

// Write a program to convert binary numbers to their decimal representation.

class ConvertBinaryToDecimal
{
    private static int ToDecimal(string number)
    {
        int decimalNumber = 0;

        if (number.Length == 32 && number[0].Equals('1')) // The number is negative
        {
            for (int i = number.Length - 1, power = 0; i >= 1; i--, power++)
            {
                decimalNumber += int.Parse(number[i].ToString()) * (int)Math.Pow(2, power);
            }

            decimalNumber = int.MinValue + decimalNumber;
        }
        else // The number is positive
        {
            for (int i = number.Length - 1, power = 0; i >= 0; i--, power++)
            {
                decimalNumber += int.Parse(number[i].ToString()) * (int)Math.Pow(2, power);
            }
        }

        return decimalNumber;
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
        Console.Title = "Convert binary number to decimal number";
        
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter a binary number : ");
        string number = Console.ReadLine();

        BinaryValidation(number); // Check the inputed number

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe binary number is {0}", number);

        Console.WriteLine("\nThe decimal representation of the number is {0}", ToDecimal(number));
        
        // Check the result
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nThe decimal representation of the number is {0} <----- Embedded method for check ", Convert.ToInt32(number, 2));

        Console.WriteLine();
        Console.ResetColor();

    }
}