using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*
    Write a program that finds all prime numbers in the range [1...10 000 000]. 
    Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
*/

class SieveOfEratosthenes
{
    static void Main(string[] args)
    {
        Console.Title = "Sieve of Eratosthenes";

        bool[] isNotPrime = new bool[10000001];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Printing the prime numbers in the range [1:10 000 000]:");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n===> The numbers below 500 will be printed slowly, after that you won't be able to see the numbers{0}",
            ", because they will be printing too fast!!!");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n===> The whole printing will be completed in about 2 minutes.\n");
        Thread.Sleep(10000);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("{0}, ", 1);
        
        for (int index = 2; index <= 10000000; index++)
        {
            if (!isNotPrime[index])
            {
                Console.Write("{0}, ", index);
                if (index < 500)
                {
                    Thread.Sleep(500); 
                }
                
                int makeTrueIndex = index;

                do
                {
                    isNotPrime[makeTrueIndex] = true;
                    makeTrueIndex += index;
                } while (makeTrueIndex <= 10000000);
            }
        }
        Console.WriteLine("\n");
    
    }
}