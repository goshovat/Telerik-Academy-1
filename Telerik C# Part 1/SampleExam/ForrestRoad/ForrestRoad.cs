using System;

class ForrestRoad
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}{1}{2}", new string('.', i), "*", new string('.', n - i - 1));
        }
        for (int i = n - 2; i >= 0; i--)
        {
            Console.WriteLine("{0}{1}{2}", new string('.', i), "*", new string('.', n - i - 1));
        }
    
    }
}