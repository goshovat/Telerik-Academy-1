using System;

/*
    Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. 
    Use a sequence of if statements.
*/

class ProductSign
{
    static void Main(string[] args)
    {
        Console.Title = "Product sign";
        Console.Write("Enter the first number : ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number : ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter the third number : ");
        double thirdNumber = double.Parse(Console.ReadLine());

        if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0)
        {
            Console.WriteLine("The sign of product of the three numbers is positive.");
        }
        else if (firstNumber < 0 && secondNumber < 0 && thirdNumber > 0)
        {
            Console.WriteLine("The sign of product of the three numbers is positive.");
        }
        else if (firstNumber < 0 && secondNumber > 0 && thirdNumber < 0)
        {
            Console.WriteLine("The sign of product of the three numbers is positive.");
        }
        else if (firstNumber > 0 && secondNumber < 0 && thirdNumber < 0)
        {
            Console.WriteLine("The sign of product of the three numbers is positive.");
        }
        else if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            Console.WriteLine("The product is 0.");
        }
        else
        {
            Console.WriteLine("The sign of product of the three numbers is negative.");
        }
    }
}