using System;

class BatGoikoTower
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}{1}{0}", new string('.', height-1), "/\\");

        int counter = 2;
        int sum = 1;

        for (int i = 0, j=1; i < height - 1; i++, j++)
        {   
            if (j == sum)
            {
                sum = sum + counter;
                counter++;
                Console.WriteLine("{0}{1}{2}{3}{0}", new string('.', height - 2 -i), "/", new string('-',2*j), "\\");
            }
            else
            {
                Console.WriteLine("{0}{1}{2}{3}{0}", new string('.', height - 2 - i), "/", new string ('.', 2*(i+1)), "\\");
            }
        }
    
    }
}