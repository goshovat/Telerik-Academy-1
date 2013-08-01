using System;

class LeastMajorityMultiple
{
    static void Main(string[] args)
    {
        int[] numbers = new int[5];
        for (int i = 0; i < 5; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int min = int.MaxValue;
        int first = 0;
        int second = 0;
        int nok = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                for (int k = j + 1; k < 5; k++)
                {
                    first = numbers[i] * numbers[j] / euclidean_NOK(numbers[i], numbers[j]);
                    second = numbers[i] * numbers[k] / euclidean_NOK(numbers[i], numbers[k]);
                    nok = first * second / euclidean_NOK(first, second);
                    if (min > nok)
                    {
                        min = nok;
                    }
                }
            }
            
        }
        
        Console.WriteLine(min);
    }

    static int euclidean_NOK(int M, int N) 
    {
        while (M != N)
        {
            if (M > N) M -= N; else N -= M;
        }
        return M;
    }
}
