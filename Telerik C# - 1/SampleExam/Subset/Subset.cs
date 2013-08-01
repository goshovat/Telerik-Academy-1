using System;

class Subset
{
    static void Main(string[] args)
    {
        int s = int.Parse(Console.ReadLine());
        int size = int.Parse(Console.ReadLine());
        int counter = 0;
        int[] numbers = new int[size];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int sum;
        int flag = 0;


        if (size >= 2)
        {
            // Check if the sum of two numbers is 0
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == s)
                    {
                        flag = 1;
                        counter++;
                    }
                }
            }
        }

        if (size >= 3)
        {
            // Check if the sum of three numbers is 0
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int p = j + 1; p < numbers.Length; p++)
                    {
                        sum = numbers[i] + numbers[j] + numbers[p];
                        if (sum == s)
                        {
                            flag = 1;
                            counter++;
                        }
                    }
                }
            }
        }


        // Check if the sum of four numbers is 0
        if (size >= 4)
        {
            for (int i = 0; i < numbers.Length - 3; i++)
            {
                for (int j = i + 1; j < numbers.Length - 2; j++)
                {
                    for (int p = j + 1; p < numbers.Length - 1; p++)
                    {
                        for (int q = p + 1; q < numbers.Length; q++)
                        {
                            sum = numbers[i] + numbers[j] + numbers[p] + numbers[q];
                            if (sum == s)
                            {
                                flag = 1;
                                counter++;
                            }
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

        if (sum == s)
        {
           
            flag = 1;
            counter++;
        }

        Console.WriteLine(counter);
    }
}