using System;

/*
    Write a method ReadNumber(int start, int end) that enters an integer number 
    in given range [start…end]. If an invalid number or non-number text is entered, 
    the method should throw an exception. Using this method write a program that enters 10 numbers:
	    a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/

class Number
{
    public static int ReadNumber(int start, int end)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter a number in the range[{0}, {1}] = ", start, end);
        int number = int.Parse(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new ArgumentException(string.Format("The number is not in the range[{0}, {1}] !!!", start, end));
        }

        return number;
    }

    static void Main(string[] args)
    {
        try
        {
            int start = 1;
            int end = 100;
            for (int i = 0; i < 10; i++)
            {
                start = ReadNumber(start, end);    
            }
            
        }
        catch (FormatException) // Thrown by int.Parse
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The entered line is not a number !!!");
        }
        catch (OverflowException) // Thrown by int.Parse because the number is too big or too small
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The number is not in the range of Int32 !!!");
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