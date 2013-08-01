using System;

/*
        Write a program that safely compares floating-point numbers with precision of 0.000001. 
     * Examples:(5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true
    */

class Comparison
{
    static void Main(string[] args)
    {
        decimal num1, num2;
        Console.Write("Enter the first number : ");
        num1 = decimal.Parse(Console.ReadLine());
        Console.Write("Enter the second number : ");
        num2 = decimal.Parse(Console.ReadLine());
        bool comparision = (Math.Abs(num1 - num2) < 0.000001m);
        Console.WriteLine("{0} is equals {1} (with 0.000001 precision) - {2} ", num1, num2, comparision);
    }
}
