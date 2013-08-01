using System;
using System.Collections.Generic;

/*
    Write a method that adds two polynomials. Represent them as arrays 
    of their coefficients as in the example below:
	x2 + 5 = 1x2 + 0x + 5 -> {5, 0, 1}

    Extend the program to support also subtraction and multiplication of polynomials. 
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

    public static int[] Subtract(int[] first, int[] second)
    {
        bool isFirstBigger = first.Length > second.Length ? true : false;

        int length = first.Length < second.Length ? first.Length : second.Length;

        int[] result;

        if (isFirstBigger)
        {
            result = new int[first.Length];
        }
        else
        {
            result = new int[second.Length];
        }

        for (int i = 0; i < length; i++)
        {
            result[i] = first[i] - second[i];
        }

        for (int i = length; i < result.Length; i++)
        {
            if (isFirstBigger)
            {
                result[i] = first[i];
            }
            else
            {
                result[i] = -second[i];
            }
        }

        return result;
    }

    public static int[] Multiplicate(int[] firstArray, int[] secondArray)
    {

        int[] result = new int[firstArray.Length + secondArray.Length];

        if (firstArray.Length < secondArray.Length)
        {
            int[] temp = secondArray;
            secondArray = firstArray;
            firstArray = temp;
        }

        List<int[]> multyplication = new List<int[]>();

        // Multiply the two numbers
        for (int i = 0; i < secondArray.Length; i++)
        {
            multyplication.Add(new int[firstArray.Length + i + 1]);

            for (int j = 0; j < firstArray.Length; j++)
            {
                multyplication[i][j + i] = secondArray[i] * firstArray[j];
            }
        }

        // Sum the elements to complete the multiplication
        for (int j = 0; j < multyplication.Count; j++)
        {
            for (int k = 0; k < multyplication[j].Length; k++)
            {
                result[k] += multyplication[j][k];
            }
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

        int[] firstPolinomial = new int[] { 5, -5, 0, 5 };
        int[] secondPolinomial = new int[] { 1, 0, 2 }; //{ 1, -2, 2 };

        Console.Write("First polinomial: ");
        Print(firstPolinomial);

        Console.Write("Second polinomial: ");
        Print(secondPolinomial);

        Console.ForegroundColor = ConsoleColor.Yellow;

        int[] result = Add(firstPolinomial, secondPolinomial);
        Console.Write("First + second polinomial = ");
        Print(result);

        Console.ForegroundColor = ConsoleColor.Cyan;

        result = Subtract(firstPolinomial, secondPolinomial);
        Console.Write("First - second polinomial = ");
        Print(result);

        Console.ForegroundColor = ConsoleColor.Magenta;

        result = Multiplicate(firstPolinomial, secondPolinomial);
        Console.Write("First * second polinomial = ");
        Print(result);

        Console.WriteLine();
        Console.ResetColor();
    }
}