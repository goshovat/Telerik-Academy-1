using System;
using System.Collections.Generic;
using System.Numerics;

class Tribonacci
{
    static void Main(string[] args)
    {
        BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());

        BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());

        BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());

       uint n = uint.Parse(Console.ReadLine());

        BigInteger number = 0;

        Console.WriteLine(BigInteger.);

        switch (n)
        {
            case 1:
                Console.WriteLine(firstNumber);
                break;
            case 2:
                Console.WriteLine(secondNumber);
                break;
            case 3:
                Console.WriteLine(thirdNumber);
                break;
            default:
                for (int i = 4; i <= n; i++)
                {
                    number = firstNumber + secondNumber + thirdNumber;
                    firstNumber = secondNumber;
                    secondNumber = thirdNumber;
                    thirdNumber = number;
                }
                Console.WriteLine(number);
                break;
        }


    }
}