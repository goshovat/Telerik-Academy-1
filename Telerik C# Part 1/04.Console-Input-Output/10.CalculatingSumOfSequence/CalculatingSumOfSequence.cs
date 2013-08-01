using System;

// Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

class CalculatingSumOfSequence
{
    static void Main(string[] args)
    {
        Console.Title = "Print sum of a sequence";

        double stopPoint;
        double member;
        double sum = 1;
        int i = 2;
        Console.Write("1 ");
        do
        {
            stopPoint = sum;
            if (i % 2 == 0)
            {
                Console.Write("+ 1/{0} ", i);
                member = 1.0 / i;
            }
            else
            {
                Console.Write("- 1/{0} ", i);
                member = -(1.0 / i);
            }
            sum += member;
            i++;
        } while (Math.Abs(sum - stopPoint) >= 0.001);

        Console.WriteLine("= {0:0.000}", sum);
    }
}