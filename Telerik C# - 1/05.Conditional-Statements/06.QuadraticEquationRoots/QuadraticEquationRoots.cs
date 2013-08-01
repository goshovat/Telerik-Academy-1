using System;

/*
    Write a program that enters the coefficients a, b and c of a quadratic equation
	a*x2 + b*x + c = 0
	and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
*/

class QuadraticEquationRoots
{
    static void Main(string[] args)
    {
        Console.Title = "Find the roots of quadratic equation";
        int coeficientA = 0;
        int coeficientB = 0;
        int coeficientC = 0;

        while (coeficientA == 0 || coeficientB == 0 || coeficientC == 0)
        {
            Console.Write("Enter coeficient a = ");
            coeficientA = int.Parse(Console.ReadLine());

            Console.Write("Enter coeficient b = ");
            coeficientB = int.Parse(Console.ReadLine());

            Console.Write("Enter coeficient c = ");
            coeficientC = int.Parse(Console.ReadLine());
        }
        int discriminant = coeficientB * coeficientB - 4 * coeficientA * coeficientC;
        double root1, root2;

        if (discriminant > 0)
        {
            root1 = (-coeficientB + Math.Sqrt(discriminant)) / 2 * coeficientA;
            root2 = (-coeficientB - Math.Sqrt(discriminant)) / 2 * coeficientA;
            Console.WriteLine("The quadratic equation has two differtent real roots");
            Console.WriteLine("root1 = {0:0.000}  root2 = {1:0.000}", root1, root2);
        }
        else if (discriminant == 0)
        {
            root1 = root2 = (-coeficientB) / 2 * coeficientA;
            Console.WriteLine("The quadratic equation has two equals real roots = {0}", root1);
        }
        else
        {
            Console.WriteLine("The quadratic equation doesn't have real roots!");
        }
    }
}