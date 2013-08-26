using System;

/*
    Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
		Example: The target substring is "in". The text is as follows:

    We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are 
    drinking all the day. We will move out of it in 5 days.

	The result is: 9.
*/

class Substring
{
    static void Main(string[] args)
    {
        Console.Title = "Substring";

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a text: ");
        string text = Console.ReadLine();

        Console.Write("\nEnter a substring: ");
        string substring = Console.ReadLine();

        int counter = 0;
        int index = text.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase) ;

        while (index != -1)
        {
            counter++;
            index = text.IndexOf(substring, index + 1, StringComparison.InvariantCultureIgnoreCase);
        }

        Console.WriteLine("The substring {0} is {1} times in the text.", substring, counter);

    }
}