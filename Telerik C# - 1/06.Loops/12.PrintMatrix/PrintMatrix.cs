using System;

/*
    Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
	N = 3			N = 4
                        
    1 2 3         1 2 3 4  
    2 3 4         2 3 4 5
    3 4 5         3 4 5 6
                  4 5 6 7
*/

class PrintMatrix
{
    static void Main(string[] args)
    {
        Console.Title = "Print matrix";

        int size = new int();

        while (size < 1 || size > 19)
        {
            Console.WriteLine("Enter N (N is in the interval[1,19])");
            Console.Write("N = ");
            size = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nThe matrix is :");
        Console.WriteLine(new string('-', size * 3 - 1));

        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j <= size + i; j++)
            {
                if (size > 5)
                {
                    if (j > 9)
                    {
                        Console.Write("{0} ", j);
                    }
                    else
                    {
                        Console.Write("{0}  ", j);
                    }
                }
                else
                {
                    Console.Write("{0}  ", j);
                }
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine(new string('-', size * 3 - 1));
    }
}