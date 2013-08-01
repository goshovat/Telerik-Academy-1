using System;

// Sort 3 real values in descending order using nested if statements.

class SortValues
{
    static void Main(string[] args)
    {
        Console.Title = "Sorting values";
        Console.Write("Enter the first number : ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number : ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the third number : ");
        int thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber > secondNumber && firstNumber > thirdNumber)
        {
            Console.WriteLine("The biggest number is {0}", firstNumber);
            if (secondNumber > thirdNumber)
            {
                Console.WriteLine("The middle number is {0}", secondNumber);
                Console.WriteLine("The smallest number is {0}", thirdNumber);
            }
            else
            {
                Console.WriteLine("The middle number is {0}", thirdNumber);
                Console.WriteLine("The smallest number is {0}", secondNumber);
            }
        }
        else if (secondNumber > firstNumber && secondNumber > thirdNumber)
        {
            Console.WriteLine("The biggest number is {0}", secondNumber);
            if (firstNumber > thirdNumber)
            {
                Console.WriteLine("The middle number is {0}", firstNumber);
                Console.WriteLine("The smallest number is {0}", thirdNumber);
            }
            else
            {
                Console.WriteLine("The middle number is {0}", thirdNumber);
                Console.WriteLine("The smallest number is {0}", firstNumber);
            }
        }
        else
        {
            Console.WriteLine("The biggest number is {0}", thirdNumber);
            if (firstNumber > secondNumber)
            {
                Console.WriteLine("The middle number is {0}", firstNumber);
                Console.WriteLine("The smallest number is {0}", secondNumber);
            }
            else
            {
                Console.WriteLine("The middle number is {0}", secondNumber);
                Console.WriteLine("The smallest number is {0}", firstNumber);
            }
        }
    }
}