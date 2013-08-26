using System;

/*
    Write methods that calculate the surface of a triangle by given:
    - Side and an altitude to it; 
    - Three sides; 
    - Two sides and an angle between them. 
    Use System.Math.
*/

class Triangle
{
    private int sideA;
    private int sideB;
    private int sideC;
    private int altitudeA;
    private double angleBetweenBAndA;
    private double surface;

    // First constructor
    public Triangle(int sideA, int altitudeA)
    {
        this.sideA = sideA;
        this.altitudeA = altitudeA;
        CalculateSurface(sideA, altitudeA);
    }

    // Second constructor
    public Triangle(int sideA, int sideB, int sideC)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
        CalculateSurface(sideA, sideB, sideC);
    }

    // Third constructor
    public Triangle(int sideA, int sideB, double angleBetweenBAndA)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.angleBetweenBAndA = angleBetweenBAndA;
        CalculateSurface(sideA, sideB, angleBetweenBAndA);
    }

    // Return the value of the surface
    public double Surface
    {
        get
        {
            return this.surface;
        }
    }

    // Calculate surface - first task
    public void CalculateSurface(int sideA, int altitudeA)
    {
        this.surface = (sideA * altitudeA) / 2.0;
    }

    // Calculate surface - second task
    public void CalculateSurface(int sideA, int sideB, int sideC)
    {
        double perimeter = (sideA + sideB + sideC) / 2.0;
        this.surface = Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));
    }

    // Calculate surface - third task
    public void CalculateSurface(int sideA, int sideB, double angle)
    {
        this.surface = (sideA * sideB * Math.Sin(angle)) / 2.0;
    }

    static void Main(string[] args)
    {
        Console.Title = "Triangle surface";

        Triangle firstTriangle = new Triangle(3, 6);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("First triangle surface = {0:F2}", firstTriangle.Surface);

        Triangle secondTriangle = new Triangle(2, 4, 5);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Second triangle surface = {0:F2}", secondTriangle.Surface);

        Triangle thirdTriangle = new Triangle(5, 8, Math.PI * 30.0 / 180.0);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Third triangle surface = {0:F2}", thirdTriangle.Surface);

        Console.ResetColor();
    }
}