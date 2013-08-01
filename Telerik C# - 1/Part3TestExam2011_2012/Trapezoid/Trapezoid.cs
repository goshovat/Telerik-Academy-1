using System;

class Trapezoid
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string up = new string('.', n) + new string('*', n);
        string down = new string('*', 2 * n);
        Console.WriteLine(up);
        for (int i = 1; i < n; i++)
        {
            Console.WriteLine("{0}{1}{2}{3}", new string('.', n - i), "*", new string('.',n-2 +i), "*");
        }
        Console.WriteLine(down);    
    }
}
