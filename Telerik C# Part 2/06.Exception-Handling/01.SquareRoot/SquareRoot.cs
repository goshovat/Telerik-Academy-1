using System;

/*
    Write a program that reads an integer number and calculates and prints its square root. 
    If the number is invalid or negative, print "Invalid number". In all cases finally print 
    "Good bye". Use try-catch-finally.
*/

class SquareRoot
{
    static void Main(string[] args)
    {
        Console.Title = "Square root";

        try
        {
            Console.Write("Enter a number : ");
            // If the number is out of the range of int32 then the print line will be in magenta
            // else if the entered line is not a number  then the print line will be in red
            // else the program will continue
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentException("Invalid number"); // The print line will be in green
            }

            double squareRoot = Math.Sqrt(number);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThe square root of the number {0} is {1:F2}", number, squareRoot);
        }
        catch (FormatException) // Thrown by int.Parse
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number");
        }
        catch (OverflowException) // Thrown by int.Parse because the number is too big or too small
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Invalid number");
        }
        catch (ArgumentException ae) // Thrown because the number is negative
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Error.WriteLine(ae.Message);
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("FATAL ERROR !!!");
        }
        finally
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nGood bye!\n");
            Console.ResetColor();
        }
    }
}