using System;

/*
    Write a method that adds two polynomials. Represent them as arrays 
    of their coefficients as in the example below:
	x2 + 5 = 1x2 + 0x + 5 -> {5, 0, 1}
*/

class Polynomial
{
    public static int[] Add(int[] first, int[] second)
    {
        if (first.Length < second.Length)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }

        int[] result = new int[first.Length];

        for (int i = 0; i < second.Length; i++)
        {
            result[i] = first[i] + second[i];
        }

        for (int i = second.Length; i < result.Length; i++)
        {
            result[i] = first[i];
        }

        return result;
    }

    public static void Print(int[] array)
    {
        bool isZero = true;
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                if (array[i] > 0)
                {
                    isZero = false;
                    Console.Write("+ {0} ", array[i]);
                }
                else if (array[i] < 0)
                {
                    isZero = false;
                    Console.Write("{0} ", array[i]);
                }

            }
            else
            {
                if (array[i] > 0)
                {
                    isZero = false;
                    if (i == array.Length - 1)
                    {
                        Console.Write("{0}x^{1} ", array[i], i);
                    }
                    else
                    {
                        Console.Write("+ {0}x^{1} ", array[i], i);
                    }
                }
                else if (array[i] < 0)
                {
                    isZero = false;
                    Console.Write("{0}x^{1} ", array[i], i);
                }
            }
        }

        if (isZero)
        {
            Console.Write("0"); 
        }
        
        Console.WriteLine("\n");
    }

    static void Main(string[] args)
    {
        Console.Title = "Polynomial";

        Console.ForegroundColor = ConsoleColor.Green;

        int[] firstPolinomial = new int[] { 3, -2, 0 , -12 };
        int[] secondPolinomial = new int[] { 2, -6, 5 };

        int[] result = Add(firstPolinomial, secondPolinomial);

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write("First polinomial: ");
        Print(firstPolinomial);

        Console.Write("Second polinomial: ");
        Print(secondPolinomial);

        Console.ForegroundColor = ConsoleColor.Blue;

        Console.Write("First + second polinomial = ");
        Print(result);

        Console.WriteLine();
        Console.ResetColor();
    }
}
