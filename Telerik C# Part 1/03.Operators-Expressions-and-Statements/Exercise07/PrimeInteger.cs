using System;

// Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

class PrimeInteger
{
    static void Main(string[] args)
    {
        byte number = 101;
        byte numberSquareRoot;
        while (number > 100)
        {
            Console.Write("Enter a number from  the interval [0,100] : ");
            number = byte.Parse(Console.ReadLine());
        }
        numberSquareRoot = (byte)Math.Sqrt(number);
        for (byte counter = 2; counter <= numberSquareRoot; counter++)
        {
            if (number % counter == 0)
            {   
                // If the number can be divided without remainder by a number from the sequence, it is not prime!
                Console.WriteLine("The number {0} is not prime!", number);
                break; // Closing the loop
            }
            if (counter == numberSquareRoot - 1) // Just before closing the loop 
            {   
                Console.WriteLine("The number {0} is prime!", number);
            }
        }
    }
}
