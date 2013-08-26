using System;

/*
    You are given a sequence of positive integer values written into a string, 
    separated by spaces. Write a function that reads these values from given 
    string and calculates their sum. Example:
    string = "43 68 9 23 318" -> result = 461
*/


class SumOfIntegers
{
    private string sequence;
    private int sum;

    public SumOfIntegers(string sequence)
    {
        this.sequence = sequence;
        this.Sum = 0;
    }

    public int Sum
    {
        get
        {
            return this.sum;
        }

        set
        {
            this.sum = 0;

            string[] number = this.sequence.Split(' ');
            for (int i = 0; i < number.Length; i++)
            {
                this.sum += int.Parse(number[i]);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Sum of integers";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Enter numbers in a row splitted by interval:");
        string number = Console.ReadLine();

        SumOfIntegers integers = new SumOfIntegers(number);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nThe sum of the numbers is {0}", integers.Sum);

        Console.WriteLine();
        Console.ResetColor();
    }
}