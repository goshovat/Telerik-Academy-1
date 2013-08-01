using System;

/*
    Write a boolean expression that checks for given integer 
    if it can be divided (without remainder) by 7 and 5 in the same time. 
*/

class CheckForDivision
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number : ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(number % 5 == 0 && number % 7 == 0 ?
            "The number can be devided by 5 and 7 in the same time." :
            "The number can't be divided by 5 and 7 int the same time.");
    }
}