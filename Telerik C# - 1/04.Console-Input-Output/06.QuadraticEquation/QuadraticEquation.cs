using System;

// Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

class QuadraticEquation
{
    static void Main(string[] args)
    {
        Console.Title = "Quadratic equation";

        Console.Write("Enter the coefficient \"a\" : ");
        int coefficientA = int.Parse(Console.ReadLine());

        Console.Write("Enter the coefficient \"b\" : ");
        int coefficientB = int.Parse(Console.ReadLine());

        Console.Write("Enter the coefficient \"c\" : ");
        int coefficientC = int.Parse(Console.ReadLine());

        if (coefficientA == 0)
        {
            if (coefficientB == 0)
            {
                if (coefficientC == 0)
                {
                    Console.WriteLine("The equation is 0 = 0.");
                    Console.WriteLine("All values are appropriate for x1 and x2.");
                }
                else
                {
                    Console.WriteLine("The equation is {0} = 0.", coefficientC);
                    Console.WriteLine("There are no appropriate values for x, the equation doesn't have solution!");
                }
            }
            else
            {
                if (coefficientC == 0)
                {
                    Console.WriteLine("The equation is {0}x = 0.", coefficientB);
                    Console.WriteLine("Its root is : \nx = 0.");
                }
                else
                {
                    Console.WriteLine("The equation is {0}x + {1} = 0.", coefficientB, coefficientC);
                    Console.WriteLine("Its root is : \nx = {0:F2}.", (-coefficientC) / (double)coefficientB);
                }
            }
        }
        else
        {
            if (coefficientB == 0)
            {
                if (coefficientC == 0)
                {
                    Console.WriteLine("The quadratic equation is {0}x^2 = 0.", coefficientA);
                    Console.WriteLine("Its roots are : \nx1 = 0 \nx2 = 0");
                }
                else
                {
                    double root = -coefficientC / (double)coefficientA;
                    Console.WriteLine("The quadratic equation is {0}x^2 + {1} = 0.", coefficientA, coefficientC);
                    if (root < 0)
                    {
                        Console.WriteLine("The quadratic equation has imaginariry roots!");
                    }
                    else
                    {
                        Console.WriteLine("Its roots are : \nx1 = {0:F2} \nx2 = {1:F2}",
                           Math.Sqrt((-coefficientC) / (double)coefficientA), Math.Sqrt((-coefficientC) / (double)coefficientA));
                    }
                }
            }
            else
            {
                if (coefficientC == 0)
                {
                    Console.WriteLine("The quadratic equation is {0}x^2 + {1}x = 0.", coefficientA, coefficientB);
                    Console.WriteLine("Its roots are : \nx1 = 0 \nx2 = {0:F2}.", (-coefficientB) / (double)coefficientA);
                }
                else
                {
                    double discriminant = coefficientB * coefficientB - 4 * coefficientA * coefficientC;
                    if (discriminant > 0)
                    {
                        Console.WriteLine("The quadratic equation has two different real roots.");
                        Console.WriteLine("x1 = {0} \nx2 = {1}",
                            (-coefficientB + Math.Sqrt(discriminant)) / 2 * coefficientA,
                            (-coefficientB - Math.Sqrt(discriminant)) / 2 * coefficientA);
                    }
                    else if (discriminant == 0)
                    {
                        Console.WriteLine("The quadratic equation has two equal real roots.");
                        Console.WriteLine("x1 = x2 = {0}", (-coefficientB) / 2 * coefficientA);
                    }
                    else
                    {
                        Console.WriteLine("The quadratic equation has two different imaginary roots.");
                    }
                }


            }
        }
    }
}