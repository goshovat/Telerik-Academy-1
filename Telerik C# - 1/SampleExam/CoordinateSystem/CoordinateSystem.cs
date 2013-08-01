using System;

class CoordinateSystem
{
    static void Main(string[] args)
    {
        decimal x = decimal.Parse(Console.ReadLine());

        decimal y = decimal.Parse(Console.ReadLine());

        int quadrant = 0;

        if (x == 0 && y == 0)
        {
            quadrant = 0;
        }
        else if (x > 0 && y > 0)
        {
            quadrant = 1;
        }
        else if (x < 0 && y > 0)
        {
            quadrant = 2;
        }
        else if (x < 0 && y < 0)
        {
            quadrant = 3;
        }
        else if (x > 0 && y < 0)
        {
            quadrant = 4;
        }
        else if (x == 0)
        {
            quadrant = 5;
        }
        else if (y == 0)
        {
            quadrant = 6;
        }
        Console.WriteLine(quadrant);
    }
}