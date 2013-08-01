using System;

// We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 -> 1+1-2=0.


class Subset
{
    static void Main(string[] args)
    {
        Console.Title = "Print subset";
        int[] numbers = new int[5];
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("Enter number[{0}] = ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        int sum;
        int flag = 0;

        // Check if the sum of two numbers is 0
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == 0)
                {
                    flag = 1;
                    Console.WriteLine("The following subset has sum = 0:");
                    Console.WriteLine("Number[{0}] = {1}", i + 1, numbers[i]);
                    Console.WriteLine("Number[{0}] = {1}", j + 1, numbers[j]);
                    Console.WriteLine();
                }
            }
        }


        // Check if the sum of three numbers is 0
        for (int i = 0; i < numbers.Length - 2; i++)
        {
            for (int j = i + 1; j < numbers.Length - 1; j++)
            {
                for (int p = j + 1; p < numbers.Length; p++)
                {
                    sum = numbers[i] + numbers[j] + numbers[p];
                    if (sum == 0)
                    {
                        flag = 1;
                        Console.WriteLine("The following subset has sum = 0:");
                        Console.WriteLine("Number[{0}] = {1}", i + 1, numbers[i]);
                        Console.WriteLine("Number[{0}] = {1}", j + 1, numbers[j]);
                        Console.WriteLine("Number[{0}] = {1}", p + 1, numbers[p]);
                        Console.WriteLine();
                    }
                }
            }
        }

        // Check if the sum of four numbers is 0
        for (int i = 0; i < numbers.Length - 3; i++)
        {
            for (int j = i + 1; j < numbers.Length - 2; j++)
            {
                for (int p = j + 1; p < numbers.Length - 1; p++)
                {
                    for (int q = p + 1; q < numbers.Length; q++)
                    {
                        sum = numbers[i] + numbers[j] + numbers[p] + numbers[q];
                        if (sum == 0)
                        {
                            flag = 1;
                            Console.WriteLine("The following subset has sum = 0:");
                            Console.WriteLine("Number[{0}] = {1}", i + 1, numbers[i]);
                            Console.WriteLine("Number[{0}] = {1}", j + 1, numbers[j]);
                            Console.WriteLine("Number[{0}] = {1}", p + 1, numbers[p]);
                            Console.WriteLine("Number[{0}] = {1}", q + 1, numbers[q]);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        sum = 0;

        // check if the sum of all numbers is 0
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        if (sum == 0)
        {
            Console.WriteLine("The sum of all numbers is 0:");
            flag = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Number[{0}] = {1}", i + 1, numbers[i]);
            }
        }
        Console.WriteLine();

        if (flag == 0)
        {
            Console.WriteLine("There aren't any subset with sum 0!");
        }
    }
}