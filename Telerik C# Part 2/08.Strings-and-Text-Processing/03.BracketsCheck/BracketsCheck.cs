using System;
using System.Collections.Generic;

/*
    Write a program to check if in a given expression the brackets are put correctly.
    Example of correct expression: ((a+b)/5-d).
    Example of incorrect expression: )(a+b)).
*/

class BracketsCheck
{
    public static bool Check(string expression)
    {
        bool correct = true;
        Stack<char> brackets = new Stack<char>();

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                brackets.Push('(');
            }
            else if (expression[i] == ')') 
            {
                brackets.Pop(); // This may throw an InvalidOperationException (for example if you enter )(a+b)). 
            }                   // The first char is ')' so the program will try to Pop the element from the top of EMPTY stack
        }                       // so this will throw the exception that is going to be handle in the Main method
                                // This exception will be throw if the number of left brackets '(' are less than right ')'
        if (brackets.Count != 0)
        {
            correct = false; // This will execute if the number of left brackets '(' are more than right brackets ')'
        }

        return correct;
    }

    static void Main(string[] args)
    {
        Console.Title = "Brackets check";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter an expression: ");
        string expression = Console.ReadLine();

        try
        {
            bool areBracketsCorrect = Check(expression);

            if (areBracketsCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nAre the brackets of expression {0} correct?", expression);
                Console.WriteLine("Answer ---> {0}", areBracketsCorrect);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAre the brackets of expression {0} correct?", expression);
                Console.WriteLine("Answer ---> {0}", areBracketsCorrect);
            }
            
        }
        catch (InvalidOperationException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAre the brackets of expression {0} correct?", expression);
            Console.WriteLine("Answer ---> {0}", "False");
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}