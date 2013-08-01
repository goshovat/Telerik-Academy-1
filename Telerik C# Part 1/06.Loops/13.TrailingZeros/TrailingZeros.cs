using System;

/*
    Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	N = 10 -> N! = 3628800 -> 2
	N = 20 -> N! = 2432902008176640000 -> 4
	Does your program work for N = 50 000?
	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
*/

class TrailingZeros
{
    static void Main(string[] args)
    {
        Console.Title = "Trailing zeros";

        int number = 0;
        while (number < 1)
        {
            Console.Write("Enter a number greater than 0 : ");
            number = int.Parse(Console.ReadLine());
        }

        int zeros = 0;

        for (int i = 2; i <= number; i++)
        {
            for (int j = 5, k = 1; j <= i; k++, j = (int)Math.Pow(5, k))
            {
                if (i % j == 0)
                {
                    zeros++;
                }
            }
        }
        Console.WriteLine("Zeros are {0}.", zeros);
    }
}