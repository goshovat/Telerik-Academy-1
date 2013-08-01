using System;

/*
    Write an expression that calculates rectangle’s area by given width and height.
*/

class Rectangle
{
    static void Main(string[] args)
    {
        double width = 0, height = 0, area;
        while (width <= 0.0)
        {
            Console.Write("Enter rectangle's width : ");
            width = double.Parse(Console.ReadLine());
        }
        while (height <= 0.0)
        {
            Console.Write("Enter rectangle's height : ");
            height = double.Parse(Console.ReadLine());
        }
        area = width * height;
        Console.WriteLine("The rectangle's area is {0}", area);
    }
}

