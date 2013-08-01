using System;

// Write a program that reads the radius r of a circle and prints its perimeter and area.

class PrintPerimeterAndArea
{
    static void Main(string[] args)
    {
        Console.Title = "Print the perimiter and the area of a circle";

        Console.Write("Please, enter the radius of the circle : ");
        double radius = double.Parse(Console.ReadLine());

        Console.WriteLine("The perimiter is = {0:0.00}", 2 * Math.PI * radius);
        Console.WriteLine("The area is = {0:F2}", Math.PI * radius * radius);
    }
}