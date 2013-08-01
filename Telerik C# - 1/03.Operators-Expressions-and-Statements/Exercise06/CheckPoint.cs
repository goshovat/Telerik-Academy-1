using System;

//Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

class CheckPoint
{
    static void Main(string[] args)
    {   
        double xCoordinate = 0.0, yCoordinate = 0.0;
        Console.Write("Enter the coordinate x = ");
        xCoordinate = double.Parse(Console.ReadLine());
        Console.Write("Enter the coordinate y = ");
        yCoordinate = double.Parse(Console.ReadLine());
        double pointRadius = Math.Sqrt(xCoordinate * xCoordinate + yCoordinate * yCoordinate);
        if (pointRadius <= 5.0d)
        {
            Console.WriteLine("The point ({0},{1}) is within the circle k(0,5).", xCoordinate, yCoordinate);
        }
        else
        {
            Console.WriteLine("The point ({0},{1}) is out of the circle k(0,5)", xCoordinate, yCoordinate);
        }
    }
}
