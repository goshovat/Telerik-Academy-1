using System;

// Write a program that generates and prints to the console 10 random values in the range [100, 200].

class RandomGenerator
{
    private Random generator;

    public RandomGenerator()
    {
        this.generator = new Random();
    }

    public int RandomNumber
    {
        get
        {
            return this.generator.Next(100, 201);
            // Another solution
            // return this.generator.Next(101) + 100;
        }
    }

    static void Main(string[] args)
    {
        Console.Title = "Random generator";

        RandomGenerator generator = new RandomGenerator();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Random generated number in the range[100, 200]: ");
        Console.WriteLine(new string('-', 25));

        for (int i = 1; i <= 10; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Random number [{0}] = {1}", i, generator.RandomNumber);
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', 25));
        Console.WriteLine();

        Console.ResetColor();
    }
}