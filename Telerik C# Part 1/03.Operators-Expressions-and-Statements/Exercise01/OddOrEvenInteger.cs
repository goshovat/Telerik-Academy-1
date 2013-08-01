using System;
   
/*
    Write an expression that checks if given integer is odd or even.
*/

class OddOrEvenInteger
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number : ");
        int number = int.Parse(Console.ReadLine());
        // One way for checking the number - with if - else construction 
        if (number % 2 == 0)
        {
            Console.WriteLine("{0} is even number.", number);
        }
        else
        {
            Console.WriteLine("{0} is odd number.", number);
        }
        //another way for checking if the number is odd or even - with conditional operator ?: and bitwise operator
        Console.WriteLine((number & 1) == 0 ? "{0} is even number." : "{0} is odd number.", number);
    }
}

