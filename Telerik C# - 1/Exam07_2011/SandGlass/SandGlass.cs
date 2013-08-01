using System;

class SandGlass
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}{2}",
                new string('.', i), new string('*', n - 2*i), new string('.', i));
        }
        for (int i = n/2 ; i > -1; i--)
        {
            Console.WriteLine("{0}{1}{2}",
                new string('.', i), new string('*', n - 2 * i), new string('.', i));
        }
    
    }
}