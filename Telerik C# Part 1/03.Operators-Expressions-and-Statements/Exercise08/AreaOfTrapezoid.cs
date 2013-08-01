using System;

// Write an expression that calculates trapezoid's area by given sides a and b and height h.

class AreaOfTrapezoid
{
    static void Main(string[] args)
    {
        Console.Write("Enter side a : ");
        float sideA = float.Parse(Console.ReadLine());
        Console.Write("Enter side b : ");
        float sideB = float.Parse(Console.ReadLine());
        Console.Write("Enter height h : ");
        float height = float.Parse(Console.ReadLine());
        float area = ((sideA + sideB) * height) / 2.0f;
        Console.WriteLine("Trapezoid's area is {0}.", area);
    }
}