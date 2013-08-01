using System;

// Write a method that reverses the digits of given decimal number. Example: 256 -> 652

class DigitReverse
{
    public static string Reverse(decimal number)
    {
        char[] array = number.ToString().ToCharArray();

        for (int i = 0; i < array.Length / 2; i++)
        {
            char temp = array[i];
            array[i] = array[array.Length - i - 1];
            array[array.Length - i - 1] = temp;
        }

        string reversedNumber = new string(array);

        if (number < 0)
        {
            array[array.Length - 1] = ' ';
            reversedNumber = new string(array);
            reversedNumber = "-" + reversedNumber;
        }

        return reversedNumber;
    }
    
    static void Main(string[] args)
    {
        Console.Title = "Reverse the digits of a decimal number";

        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter the number: ");
        decimal number = decimal.Parse(Console.ReadLine());

        string reversedNumber = Reverse(number);

        Console.ForegroundColor = ConsoleColor.Yellow;       
        Console.WriteLine("\nThe number is {0} and its reverse reflection is {1}", number, reversedNumber);

        Console.WriteLine();
        Console.ResetColor();
    }
}
