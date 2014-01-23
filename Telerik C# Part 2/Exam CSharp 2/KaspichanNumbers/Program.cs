using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class KaspichanNumbers
{
    static void Main()
    {
        BigInteger myNumber = BigInteger.Parse(Console.ReadLine());

        StringBuilder inLetters = new StringBuilder();

        if (myNumber == 0)
        {
            Console.WriteLine("A");
        }
        else
        {
            while (myNumber != 0)
            {
                inLetters.Insert(0, convertToKaspichan((int)(myNumber % 256)));
                myNumber /= 256;
            }
        Console.WriteLine(inLetters.ToString());
        }
    }

    static string convertToKaspichan(int digits)
    {
        int first = digits / 26;
        int secound = digits % 26;
        if (first > 0)
        {
            return ((char)(first + 96)).ToString() + ((char)(secound + 65)).ToString();
        }
        else
        {
            return ((char)(secound + 65)).ToString();
        }
    }
}
