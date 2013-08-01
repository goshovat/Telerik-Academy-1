using System;

// Write a program that finds the greatest of given 5 variables.

class PrintGreatestNumber
{
    static void Main(string[] args)
    {
        Console.Title = "Print greatest number";
        double[] numbers = new double[5];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number[{0}] = ", i + 1);
            numbers[i] = double.Parse(Console.ReadLine());
        }
        double greatestNumber = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (greatestNumber < numbers[i])
            {
                greatestNumber = numbers[i];
            }
        }
        Console.WriteLine("The greatest number is {0:F2}!", greatestNumber);
    }
}